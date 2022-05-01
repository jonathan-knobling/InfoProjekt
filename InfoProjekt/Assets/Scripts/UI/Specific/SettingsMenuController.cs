using Tech.IO.PlayerInput;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Specific
{
    public class SettingsMenuController: MonoBehaviour
    {
        [SerializeField] private UIDocument previousMenu;
        [SerializeField] private UIDocument settingsMenu;
        [SerializeField] private InputChannelSO inputChannel;

        private VisualElement root;
        
        private Button backButton;

        private void Awake()
        {
            root = settingsMenu.rootVisualElement;
            
            backButton = root.Q<Button>("back_button");
            
            backButton.clicked += BackButtonPressed;
            inputChannel.OnEscapeButtonPressed += EscapeButtonPressed;

            settingsMenu.enabled = false;
        }

        private void EscapeButtonPressed()
        {
            if (settingsMenu.enabled)
            {
                BackButtonPressed();
            }
        }

        private void BackButtonPressed()
        {
            previousMenu.enabled = true;
            settingsMenu.enabled = false;
        }
    }
}