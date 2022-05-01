using Tech.Flow;
using Tech.IO.PlayerInput;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Specific
{
    public class PauseMenuController : MonoBehaviour
    {
        [SerializeField] private FlowChannelSO flowChannel;
        [SerializeField] private InputChannelSO inputChannel;
        
        [Header("UI Documents")]
        [SerializeField] private UIDocument pauseMenu;
        [SerializeField] private UIDocument saveMenu;
        [SerializeField] private UIDocument settingsMenu;

        private Button resumeButton;
        private Button saveButton;
        private Button optionsButton;
        private Button quitButton;
        
        void Awake()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;
            
            resumeButton = root.Q<Button>("resume_button");
            saveButton = root.Q<Button>("save_button");
            optionsButton = root.Q<Button>("options_button");
            quitButton = root.Q<Button>("quit_button");
            
            resumeButton.clicked += ResumeButtonPressed;
            saveButton.clicked += SaveButtonPressed;
            optionsButton.clicked += OptionsButtonPressed;
            quitButton.clicked += QuitButtonPressed;
            
            inputChannel.OnEscapeButtonPressed += EscapeButtonPressed;
            
            pauseMenu.enabled = false;
        }
        
        private void SaveButtonPressed()
        {
            saveMenu.enabled = true;
            pauseMenu.enabled = false;
        }

        private void EscapeButtonPressed()
        {
            if (!pauseMenu.enabled)
            {
                flowChannel.ChangeFlowState(FlowState.Paused);
                pauseMenu.enabled = true;
            }
            else
            {
                ResumeButtonPressed();
            }
        }
        
        private void ResumeButtonPressed()
        {
            flowChannel.ChangeFlowState(FlowState.Default);
            pauseMenu.enabled = false;
        }
        
        private void OptionsButtonPressed()
        {
            settingsMenu.enabled = true;
        }
        
        private void QuitButtonPressed()
        {
            Application.Quit();
        }
    }
}
