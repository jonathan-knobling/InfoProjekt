using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tech.IO.Saves
{
    public class SceneSaveManager: MonoBehaviour
    {
        private const string SaveKey = "saved_scene"; 
        
        [SerializeField] private SaveChannelSO saveChannel;

        private string savedScene;
        
        private void Start()
        {
            saveChannel.OnLoad += LoadSavedScene;
        }

        [ContextMenu("Save Current Scene")]
        private void SaveCurrentScene()
        {
            Debug.Log("Save: " + SceneManager.GetActiveScene().name);
            saveChannel.Save(SaveKey, SceneManager.GetActiveScene().name);
        }

        private void LoadSavedScene(Dictionary<string, object> dictionary)
        {
            Debug.Log("Load Scene");
            savedScene = (string) dictionary[SaveKey];
            saveChannel.SaveGameState();
            SceneManager.LoadScene(savedScene);
        }

        private void OnApplicationQuit()
        {
            SaveCurrentScene();
        }
    }
}