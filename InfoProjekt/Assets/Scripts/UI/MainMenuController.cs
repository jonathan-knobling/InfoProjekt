using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace UI
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
            playButton.clicked += playButtonPressed;
            settingsButton.clicked += settingsButtonPressed;
            settingsBackButton.clicked += settingsBackButtonPressed;
        }

        void playButtonPressed()
        {
            SceneManager.LoadScene("Spawn");
        }

        void settingsButtonPressed()
        {
            settingsScreen.style.display = DisplayStyle.Flex;
            mainMenuScreen.style.display = DisplayStyle.None;
        }

        void settingsBackButtonPressed()
        {
            settingsScreen.style.display = DisplayStyle.None;
            mainMenuScreen.style.display = DisplayStyle.Flex;
        }
    }
}
