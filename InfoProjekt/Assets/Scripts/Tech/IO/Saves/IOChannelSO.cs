using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Tech.IO.Saves
{
    [CreateAssetMenu(menuName = "Channels/Save Channel")]
    public class IOChannelSO: ScriptableObject
    {
        public event Action<string, object> OnSaveData;
        public event Action<string> OnSaveToFile;
        public event Action<Dictionary<string, object>> OnLoadData;
        public event Action<string> OnLoadSaveFile;
 
        [Description("Add Data to be Saved")]
        public void SaveData(string key, object data)
        {
            OnSaveData?.Invoke(key, data);
        }

        [Description("Save the current Game State")]
        public void SaveToFile(string fileName)
        {
            OnSaveToFile?.Invoke(fileName);
        }
        
        [Description("Calls the OnLoad event and gives load data to every subscriber")]
        public void Load(Dictionary<string, object> data)
        {
            OnLoadData?.Invoke(data);
        }
        
        [Description("Load Game State from a File")]
        public void LoadSaveFile(string path)
        {
            OnLoadSaveFile?.Invoke(path);
        }
    }
}