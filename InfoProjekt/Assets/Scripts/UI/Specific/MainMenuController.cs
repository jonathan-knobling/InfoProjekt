using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Specific
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private UIDocument mainMenu;
        [SerializeField] private UIDocument settingsMenu;
        [SerializeField] private UIDocument loadMenu;

        //Main Menu
        private Button mainMenuPlayButton;
        private Button mainMenuSettingsButton;
        
        //Settings Menu
        private Button settingsMenuBackButton;
        
        //Load Menu
        private Button loadMenuBackButton;

        void Start()
        {
            Time.timeScale = 0f;
            
            //Main Menu init
            mainMenuPlayButton = mainMenu.rootVisualElement.Q<Button>("play_button");
            mainMenuSettingsButton = mainMenu.rootVisualElement.Q<Button>("settings_button");
            
            //Settings Menu init
            settingsMenuBackButton = settingsMenu.rootVisualElement.Q<Button>("back_button");
            
            //Load Menu init
            loadMenuBackButton = loadMenu.rootVisualElement.Q<Button>("back_button");
            
            
            //Main Menu events
            mainMenuPlayButton.clicked += MenuPlayButtonPressed;
            mainMenuSettingsButton.clicked += MainMenuSettingsButtonPressed;
            
            //Settings Menu events
            settingsMenuBackButton.clicked += SettingsMenuBackButtonPressed;
            
            
            loadMenu.enabled = false;
            settingsMenu.enabled = false;
        }

        void MenuPlayButtonPressed()
        {
            loadMenu.enabled = true;
            mainMenu.enabled = false;
        }

        void MainMenuSettingsButtonPressed()
        {
            settingsMenu.enabled = true;
            mainMenu.enabled = false;
        }

        void SettingsMenuBackButtonPressed()
        {
            settingsMenu.enabled = false;
            mainMenu.enabled = true;
        }
    }
}
