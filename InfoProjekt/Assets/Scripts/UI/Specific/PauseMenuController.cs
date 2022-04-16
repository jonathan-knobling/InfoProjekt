using Tech.Flow;
using Tech.IO;
using Tech.IO.PlayerInput;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Specific
{
    public class PauseMenuController : MonoBehaviour
    {
        [SerializeField] private UIDocument saveMenuUI;
        [SerializeField] private FlowChannelSO flowChannel;
        [SerializeField] private InputChannelSO inputChannel;
        
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
            pauseMenu = root.Q<VisualElement>("pause_menu");
            optionsMenu = root.Q<VisualElement>("options_menu");

            resumeButton = root.Q<Button>("resume_button");
            saveButton = root.Q<Button>("save_button");
            optionsButton = root.Q<Button>("options_button");
            quitButton = root.Q<Button>("quit_button");

            optionsBackButton = root.Q<Button>("back_button");

            resumeButton.clicked += ResumeButtonPressed;
            saveButton.clicked += SaveButtonPressed;
            optionsButton.clicked += OptionsButtonPressed;
            quitButton.clicked += QuitButtonPressed;

            optionsBackButton.clicked += OptionsBackButtonPressed;

            inputChannel.OnPauseButtonPressed += PauseButtonPressed;
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
                flowChannel.ChangeFlowState(FlowState.Paused);
                screen.style.display = DisplayStyle.Flex;
            }
            else
            {
                ResumeButtonPressed();
            }
        }

        void ResumeButtonPressed()
        {
            flowChannel.ChangeFlowState(FlowState.Default);
            screen.style.display = DisplayStyle.None;
            
            // falls man während man im options menu is esc drückt
            OptionsBackButtonPressed(); 
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
