using Tech.IO.Saves;
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
        [SerializeField] private SaveChannelSO saveChannel;

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
            
            loadMenu.rootVisualElement.style.display = DisplayStyle.None;
            settingsMenu.rootVisualElement.style.display = DisplayStyle.None;
        }

        private void PlayButtonPressed()
        {
            saveChannel.SaveGameState();
            SceneManager.LoadScene("Spawn");
            Time.timeScale = 1f;
        }
        
        private void LoadButtonPressed()
        {
            loadMenu.rootVisualElement.style.display = DisplayStyle.Flex;
            mainMenu.rootVisualElement.style.display = DisplayStyle.None;
        }

        private void SettingsButtonPressed()
        {
            settingsMenu.rootVisualElement.style.display = DisplayStyle.Flex;
            mainMenu.rootVisualElement.style.display = DisplayStyle.None;
        }

        private void QuitButtonPressed()
        {
            Application.Quit();
        }
    }
}
