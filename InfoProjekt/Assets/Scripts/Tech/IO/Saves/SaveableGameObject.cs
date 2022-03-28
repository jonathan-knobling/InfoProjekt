using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tech.IO.Saves
{
    public class SaveableGameObject: MonoBehaviour
    {
        [SerializeField] private string id = String.Empty;

        public string ID => id;

        [ContextMenu("Generate ID")]
        private void GenerateID() => id = Guid.NewGuid().ToString();

        public object SerializeGameObject()
        {
            var serializedGameObject = new Dictionary<string, object>();

            foreach (var saveable in GetComponents<ISaveable>())
            {
                serializedGameObject[saveable.GetType().ToString()] = saveable.SerializeComponent();
            }

            return serializedGameObject;
        }

        public void ApplySerializedData(object o)
        {
            var serializedGameObject = (Dictionary<string, object>) o;

            foreach (var saveable in GetComponents<ISaveable>())
            {
                string type = saveable.GetType().ToString();

                if (serializedGameObject.TryGetValue(type, out object data))
                {
                    saveable.ApplySerializedData(data);
                }
            }
        }
    }
}