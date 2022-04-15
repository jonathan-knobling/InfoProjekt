using System;
using System.Collections.Generic;
using System.Linq;
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
 
        public void SaveData(string key, object data)
        {
            OnSaveData?.Invoke(key, data);
        }

        public void SaveToFile(string fileName)
        {
            OnSaveToFile?.Invoke(fileName);
        }

        public void Load(Dictionary<string, object> data)
        {
            OnLoadData?.Invoke(data);
        }
        
        //todo add load saved scene to onload

        public void LoadSaveFile(string path)
        {
            OnLoadSaveFile?.Invoke(path);
        }
    }
}