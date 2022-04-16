using System.Collections.Generic;
using UnityEngine;

namespace Tech.IO.Saves
{
    public class SaveManager: MonoBehaviour
    {
        [SerializeField] private IOChannelSO ioChannel;
        
        private Dictionary<string, object> saveBuffer;
        
        private string SavePath => Application.persistentDataPath + "/saves/";
        
        
        private void Start()
        {
            ioChannel.OnSaveToFile += Save;
            ioChannel.OnSaveData += AddToSafeBuffer;
            ioChannel.OnLoadSaveFile += LoadFile;
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
        
        
        private void Save(string fileName)
        {
            //erst loaden damit andere scenen nich ge overwritet werden
            var serializedData = SaveIO.LoadFile(fileName);
            
            //save current scene
            KeyValuePair<string, object> scene = SceneSaveManager.SaveCurrentScene();
            if (!serializedData.TryAdd(scene.Key, scene.Value))
            {
                serializedData[scene.Key] = scene.Value;
            }

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
            SerializeGameState(serializedData);
            //save the file
            SaveIO.SaveFile(serializedData, SavePath + fileName);
        }
        

        private void LoadFile(string path)
        {
            var serializedData = SaveIO.LoadFile(path);
            SceneSaveManager.LoadSavedScene(serializedData);
            ioChannel.Load(serializedData);
            ApplySerializedStateData(serializedData);
        }
        

        private void SerializeGameState(Dictionary<string, object> serializedData)
        {
            //jedes saveable gameobject in der activen scene serializen und ins save dictionary packen
            foreach (var saveable in FindObjectsOfType<SaveableGameObject>())
            {
                serializedData[saveable.ID] = saveable.SerializeGameObject();
            }
        }
        

        private void ApplySerializedStateData(Dictionary<string, object> serializedData)
        {
            //jedes saveable gameobject in der activen scene aus dem dictionary die serializete data holen mit der ID
            foreach (var saveable in FindObjectsOfType<SaveableGameObject>())
            {
                if (serializedData.TryGetValue(saveable.ID, out object data))
                {
                    saveable.ApplySerializedStateData(data);
                }
            }
        }
        

        private void OnApplicationQuit()
        {
            Save(SaveIO.GenerateNewFileName("auto"));
        }
    }
}