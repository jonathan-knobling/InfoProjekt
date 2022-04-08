using System;
using UnityEngine;
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
        private Button settingsButton;
        private Button quitButton;

        private void Awake()
        {
            root = mainMenu.rootVisualElement;
            
            playButton = root.Q<Button>("play_button");
            settingsButton = root.Q<Button>("settings_button");
            quitButton = root.Q<Button>("quit_button");
            
            playButton.clicked += MenuPlayButtonPressed;
            settingsButton.clicked += MainMenuSettingsButtonPressed;
            quitButton.clicked += QuitButtonPressed;
        }

        void Start()
        {
            Time.timeScale = 0f;
            
            loadMenu.rootVisualElement.style.display = DisplayStyle.None;
            settingsMenu.rootVisualElement.style.display = DisplayStyle.None;
        }

        private void MenuPlayButtonPressed()
        {
            loadMenu.rootVisualElement.style.display = DisplayStyle.Flex;
            mainMenu.rootVisualElement.style.display = DisplayStyle.None;
        }

        private void MainMenuSettingsButtonPressed()
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
