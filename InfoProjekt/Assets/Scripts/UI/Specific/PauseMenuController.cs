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

            eventChannel.InputChannel.OnEscapeButtonPressed += EscapeButtonPressed;
            
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
                eventChannel.FlowChannel.ChangeFlowState(FlowState.Paused);
                pauseMenu.enabled = true;
            }
            else
            {
                ResumeButtonPressed();
            }
        }
        
        private void ResumeButtonPressed()
        {
            eventChannel.FlowChannel.ChangeFlowState(FlowState.Default);
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
