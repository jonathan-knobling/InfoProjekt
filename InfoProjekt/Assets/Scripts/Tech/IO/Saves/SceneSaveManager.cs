using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Tech.IO.Saves
{
    public static class SceneSaveManager
    {
        private const string SaveKey = "saved_scene";

        public static KeyValuePair<string, object> SaveCurrentScene()
        {
            return new KeyValuePair<string, object>(SaveKey, SceneManager.GetActiveScene().name);
        }

        public static void LoadSavedScene(Dictionary<string, object> dictionary)
        {
            SceneManager.LoadScene((string) dictionary[SaveKey]);
        }
    }
}