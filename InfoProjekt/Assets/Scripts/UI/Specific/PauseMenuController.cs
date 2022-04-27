using Tech;
using Tech.Flow;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Specific
{
    public class PauseMenuController : MonoBehaviour
    {
        [SerializeField] private UIDocument saveMenuUI;
        [SerializeField] private EventChannelSO eventChannel;
        
        private VisualElement root;

        private VisualElement screen;
        private VisualElement pauseMenu;
        private VisualElement optionsMenu;

        private Button resumeButton;
        private Button saveButton;
        private Button optionsButton;
        private Button quitButton;

        private Button optionsBackButton;

        void Start()
        {
            root = GetComponent<UIDocument>().rootVisualElement;

            screen = root.Q<VisualElement>("screen");

            resumeButton = root.Q<Button>("resume_button");
            saveButton = root.Q<Button>("save_button");
            optionsButton = root.Q<Button>("options_button");
            quitButton = root.Q<Button>("quit_button");

            resumeButton.clicked += ResumeButtonPressed;
            saveButton.clicked += SaveButtonPressed;
            optionsButton.clicked += OptionsButtonPressed;
            quitButton.clicked += QuitButtonPressed;

            eventChannel.InputChannel.OnPauseButtonPressed += PauseButtonPressed;
        }

        private void SaveButtonPressed()
        {
            saveMenuUI.enabled = true;
            screen.style.display = DisplayStyle.None;
        }

        private void PauseButtonPressed()
        {
            if (!screen.style.display.Equals(DisplayStyle.Flex))
            {
                eventChannel.FlowChannel.ChangeFlowState(FlowState.Paused);
                screen.style.display = DisplayStyle.Flex;
            }
            else
            {
                ResumeButtonPressed();
            }
        }

        void ResumeButtonPressed()
        {
            eventChannel.FlowChannel.ChangeFlowState(FlowState.Default);
            screen.style.display = DisplayStyle.None;
        }

        void OptionsButtonPressed()
        {
            optionsMenu.style.display = DisplayStyle.Flex;
            pauseMenu.style.display = DisplayStyle.None;
        }

        void QuitButtonPressed()
        {
            Application.Quit();
        }
    }
}
