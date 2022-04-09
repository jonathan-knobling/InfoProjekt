using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tech.IO.Saves
{
    [CreateAssetMenu(menuName = "Channels/Save Channel")]
    public class SaveChannelSO: ScriptableObject
    {
        public event Action<string, object> OnSave;
        public event Action OnSaveGameState;
        public event Action<Dictionary<string, object>> OnLoad;
        public event Action<string> OnLoadSaveFile;
 
        public void Save(string key, object data)
        {
            OnSave?.Invoke(key, data);
        }

        public void SaveGameState()
        {
            OnSaveGameState?.Invoke();
        }

        public void Load(Dictionary<string, object> data)
        {
            Debug.Log(data.Keys.Contains("saved_scene"));
            OnLoad?.Invoke(data);
        }

        public void LoadSaveFile(string path)
        {
            OnLoadSaveFile?.Invoke(path);
        }
    }
}