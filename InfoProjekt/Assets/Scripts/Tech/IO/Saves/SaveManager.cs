using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Tech.IO.Saves
{
    public class SaveManager: MonoBehaviour
    {
        [SerializeField] private SaveChannelSO saveChannel;
        
        private Dictionary<string, object> saveBuffer;
        
        private string SavePath => Application.persistentDataPath + "/saves/default.dmg";
        
        private void Start()
        {
            saveChannel.OnSaveGameState += Save;
            saveChannel.OnSave += AddToSafeBuffer;
            saveChannel.OnLoadSaveFile += Load;
            saveBuffer = new Dictionary<string, object>();
        }
            
        private void AddToSafeBuffer(string key, object data)
        {
            //wenn es noch nich gibt neu adden in den buffer
            if (!saveBuffer.TryAdd(key, data))
            {
                //ansonsten value überschreiben
                saveBuffer[key] = data;
            }
        }
        
        [ContextMenu("Save")]
        private void Save()
        {
            //erst loaden damit andere scenen nich ge overwritet werden
            var serializedData = LoadFile();

            //apply save buffer
            foreach (var (key, value) in saveBuffer)
            {
                //wenn es noch nich gibt neu adden
                if (!serializedData.TryAdd(key, value))
                {
                    //ansonsten value überschreiben
                    serializedData[key] = value;
                }
            }
            saveBuffer.Clear();
            
            //load new changes from game
            SerializeGame(serializedData);
            //save the file
            SaveFile(serializedData);
        }
        
        [ContextMenu("Load")]
        private void Load()
        {
            Load(SavePath);
        }
        
        private void Load(string path)
        {
            Debug.Log("Load");
            var serializedData = LoadFile(path);
            saveChannel.Load(serializedData);
            ApplySerializedData(serializedData);
        }
        
        private void SaveFile(object data)
        {
            using (var stream = File.Open(SavePath, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, data);
            }
        }

        private Dictionary<string, object> LoadFile()
        {
            return LoadFile(SavePath);
        }
        
        private Dictionary<string, object> LoadFile(string path)
        {
            //wenn es noch keinen save file gibt
            if (!File.Exists(path))
            {
                return new Dictionary<string, object>();
            }

            //file stream machen und deserializete data in dictionary packen
            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                return (Dictionary<string, object>) formatter.Deserialize(stream);
            }
        }

        private void SerializeGame(Dictionary<string, object> serializedData)
        {
            //jedes saveable gameobject in der activen scene serializen und ins save dictionary packen
            foreach (var saveable in FindObjectsOfType<SaveableGameObject>())
            {
                serializedData[saveable.ID] = saveable.SerializeGameObject();
            }
        }

        private void ApplySerializedData(Dictionary<string, object> serializedData)
        {
            //jedes saveable gameobject in der activen scene aus dem dictionary die serializete data holen mit der ID
            foreach (var saveable in FindObjectsOfType<SaveableGameObject>())
            {
                if (serializedData.TryGetValue(saveable.ID, out object data))
                {
                    saveable.ApplySerializedData(data);
                }
            }
        }

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}