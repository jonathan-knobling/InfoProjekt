using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tech.IO.Saves
{
    public class SceneSaveManager: MonoBehaviour
    {
        private const string SaveKey = "saved_scene"; 
        
        private SaveChannelSO saveChannel;

        private string savedScene;
        
        private void Start()
        {
            saveChannel.OnLoad += LoadSavedScene;
        }

        private void SaveCurrentScene()
        {
            saveChannel.Save(SaveKey, SceneManager.GetActiveScene().name);
        }

        private void LoadSavedScene(Dictionary<string, object> dictionary)
        {
            savedScene = (string) dictionary[SaveKey];
        }
    }
}