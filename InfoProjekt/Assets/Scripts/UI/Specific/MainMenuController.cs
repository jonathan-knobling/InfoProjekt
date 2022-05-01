using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace UI.Specific
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private UIDocument mainMenu;
        [SerializeField] private UIDocument settingsMenu;
        [SerializeField] private UIDocument loadMenu;

        private VisualElement root;
        
        private Button playButton;
        private Button loadButton;
        private Button settingsButton;
        private Button quitButton;

        private void Awake()
        {
            root = mainMenu.rootVisualElement;
            
            playButton = root.Q<Button>("play_button");
            loadButton = root.Q<Button>("load_button");
            settingsButton = root.Q<Button>("settings_button");
            quitButton = root.Q<Button>("quit_button");
            
            playButton.clicked += PlayButtonPressed;
            loadButton.clicked += LoadButtonPressed;
            settingsButton.clicked += SettingsButtonPressed;
            quitButton.clicked += QuitButtonPressed;
        }

        void Start()
        {
            Time.timeScale = 0f;

            loadMenu.enabled = false;
            settingsMenu.enabled = false;
        }

        private void PlayButtonPressed()
        {
            SceneManager.LoadScene("Spawn");
            Time.timeScale = 1f;
        }
        
        private void LoadButtonPressed()
        {
            loadMenu.enabled = true;
            mainMenu.enabled = false;
        }

        private void SettingsButtonPressed()
        {
            settingsMenu.enabled = true;
            mainMenu.enabled = false;
        }

        private void QuitButtonPressed()
        {
            Application.Quit();
        }
    }
}
