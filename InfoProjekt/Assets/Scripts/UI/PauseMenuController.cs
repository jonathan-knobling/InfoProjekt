using Flow;
using Flow.States;
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

            resumeButton.clicked += ResumeButtonPressed;
            optionsButton.clicked += OptionsButtonPressed;
            quitButton.clicked += QuitButtonPressed;

            optionsBackButton.clicked += OptionsBackButtonPressed;
        }

        void Update()
        {
            //pause menu aktivieren und deaktivieren wenn input esc
            if (Input.GetButtonDown("Pause"))
            {
                if (!screen.style.display.Equals(DisplayStyle.Flex))
                {
                    FlowStateManager.Instance.ChangeState(new FlowStatePaused());
                    screen.style.display = DisplayStyle.Flex;
                }
                else
                {
                    ResumeButtonPressed();
                }
            }
        }

        void ResumeButtonPressed()
        {
            FlowStateManager.Instance.ChangeState(new FlowStateDefault());
            screen.style.display = DisplayStyle.None;
            OptionsBackButtonPressed(); // falls man während man im options menu is esc drückt
        }

        void OptionsButtonPressed()
        {
            optionsMenu.style.display = DisplayStyle.Flex;
            pauseMenu.style.display = DisplayStyle.None;
        }

        void OptionsBackButtonPressed()
        {
            optionsMenu.style.display = DisplayStyle.None;
            pauseMenu.style.display = DisplayStyle.Flex;
        }

        void QuitButtonPressed()
        {
            Application.Quit();
        }
    }
}
