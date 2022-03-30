using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tech.IO.Saves
{
    [CreateAssetMenu(menuName = "Channels/Save Channel")]
    public class SaveChannelSO: ScriptableObject
    {
        public event Action<string, object> OnSave;
        public event Action<Dictionary<string, object>> OnLoad;
 
        public void Save(string key, object data)
        {
            OnSave?.Invoke(key, data);
        }

        public void Load(Dictionary<string, object> data)
        {
            OnLoad?.Invoke(data);
        }
    }
}