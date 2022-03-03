using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class PauseMenuController : MonoBehaviour
    {

        private VisualElement root;

        private VisualElement screen;
        private VisualElement pauseMenu;
        private VisualElement optionsMenu;

        private Button resumeButton;
        private Button optionsButton;
        private Button quitButton;

        private Button optionsBackButton;

        void Start()
        {
            root = GetComponent<UIDocument>().rootVisualElement;

            screen = root.Q<VisualElement>("screen");
            pauseMenu = root.Q<VisualElement>("pause_menu");
            optionsMenu = root.Q<VisualElement>("options_menu");

            resumeButton = root.Q<Button>("resume_button");
            optionsButton = root.Q<Button>("options_button");
            quitButton = root.Q<Button>("quit_button");

            optionsBackButton = root.Q<Button>("back_button");

            resumeButton.clicked += resumeButtonPressed;
            optionsButton.clicked += optionsButtonPressed;
            quitButton.clicked += quitButtonPressed;

            optionsBackButton.clicked += optionsBackButtonPressed;
        }

        void Update()
        {
            //pause menu aktivieren und deaktivieren wenn input esc
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log(screen.style.display);
                if (!screen.style.display.Equals(DisplayStyle.Flex))
                {
                    Time.timeScale = 0;
                    screen.style.display = DisplayStyle.Flex;
                }
                else
                {
                    resumeButtonPressed();
                }
            }
        }

        void resumeButtonPressed()
        {
            Time.timeScale = 1;
            screen.style.display = DisplayStyle.None;
            optionsBackButtonPressed(); // falls man während man im options menu is esc drückt
        }

        void optionsButtonPressed()
        {
            optionsMenu.style.display = DisplayStyle.Flex;
            pauseMenu.style.display = DisplayStyle.None;
        }

        void optionsBackButtonPressed()
        {
            optionsMenu.style.display = DisplayStyle.None;
            pauseMenu.style.display = DisplayStyle.Flex;
        }

        void quitButtonPressed()
        {
            Application.Quit();
        }
    }
}
