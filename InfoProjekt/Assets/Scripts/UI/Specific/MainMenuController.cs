using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace UI.Specific
{
    public class MainMenuController : MonoBehaviour
    {

        private Button playButton;
        private Button settingsButton;
        private Button settingsBackButton;

        private VisualElement settingsScreen;
        private VisualElement mainMenuScreen;

        void Start()
        {
            //visual element root also wo alles drinne is getten
            var root = GetComponent<UIDocument>().rootVisualElement;

            //buttons vom root getten
            playButton = root.Q<Button>("play_button");
            settingsButton = root.Q<Button>("settings_button");
            settingsBackButton = root.Q<Button>("back_button");

            //settings und main menu screen getten
            settingsScreen = root.Q<VisualElement>("settings");
            mainMenuScreen = root.Q<VisualElement>("main_menu");

            //die Funktionen den Buttons hinzufügen
            playButton.clicked += PlayButtonPressed;
            settingsButton.clicked += SettingsButtonPressed;
            settingsBackButton.clicked += SettingsBackButtonPressed;
        }

        void PlayButtonPressed()
        {
            SceneManager.LoadScene("Spawn");
        }

        void SettingsButtonPressed()
        {
            settingsScreen.style.display = DisplayStyle.Flex;
            mainMenuScreen.style.display = DisplayStyle.None;
        }

        void SettingsBackButtonPressed()
        {
            settingsScreen.style.display = DisplayStyle.None;
            mainMenuScreen.style.display = DisplayStyle.Flex;
        }
    }
}
