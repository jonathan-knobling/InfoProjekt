using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Specific
{
    public class SettingsMenuController: MonoBehaviour
    {
        [SerializeField] private UIDocument mainMenu;
        [SerializeField] private UIDocument settingsMenu;

        private VisualElement root;
        
        private Button backButton;

        private void Awake()
        {
            root = settingsMenu.rootVisualElement;
            
            backButton = root.Q<Button>("back_button");
            
            backButton.clicked += BackButtonPressed;
        }

        private void BackButtonPressed()
        {
            mainMenu.rootVisualElement.style.display = DisplayStyle.Flex;
            settingsMenu.rootVisualElement.style.display = DisplayStyle.None;
        }
    }
}