using Tech;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Specific
{
    public class SettingsMenuController: MonoBehaviour
    {
        [SerializeField] private UIDocument previousMenu;
        [SerializeField] private UIDocument settingsMenu;
        [SerializeField] private EventChannelSO eventChannel;

        private VisualElement root;
        
        private Button backButton;

        private void Awake()
        {
            root = settingsMenu.rootVisualElement;
            
            backButton = root.Q<Button>("back_button");
            
            backButton.clicked += BackButtonPressed;
            eventChannel.InputChannel.OnPauseButtonPressed += BackButtonPressed;
        }

        private void BackButtonPressed()
        {
            previousMenu.rootVisualElement.style.display = DisplayStyle.Flex;
            settingsMenu.rootVisualElement.style.display = DisplayStyle.None;
        }
    }
}