using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tech.IO.Saves
{
    public class SaveManager: MonoBehaviour
    {
        private string SavePath => Application.persistentDataPath + "/save.dmg";

        private void Start()
        {
            //Load();
            SceneManager.activeSceneChanged += Save;
        }

        //overload um zu activeSceneChanged subben zu können
        private void Save(Scene arg0, Scene scene)
        {
            Save();
        }
        
        [ContextMenu("Save")]
        private void Save()
        {
            //erst loaden damit andere scenen nich ge overwritet werden
            var serializedData = LoadFile();
            SerializeGame(serializedData);
            SaveFile(serializedData);
        }
        
        [ContextMenu("Load")]
        private void Load()
        {
            var serializedData = LoadFile();
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
            //wenn es noch keinen save file gibt
            if (!File.Exists(SavePath))
            {
                return new Dictionary<string, object>();
            }

            //file stream machen und deserializete data in dictionary packen
            using (FileStream stream = File.Open(SavePath, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                return (Dictionary<string, object>) formatter.Deserialize(stream);
            }
        }

        private void SerializeGame(Dictionary<string, object> serializedData)
        {
            //jedes saveable gameobject in der activen scene serializen und ins save dictionary packen
            foreach (var saveable in GameObject.FindObjectsOfType<SaveableGameObject>())
            {
                serializedData[saveable.ID] = saveable.SerializeGameObject();
            }
        }

        private void ApplySerializedData(Dictionary<string, object> serializedData)
        {
            //jedes saveable gameobject in der activen scene aus dem dictionary die serializete data holen mit der ID
            foreach (var saveable in GameObject.FindObjectsOfType<SaveableGameObject>())
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