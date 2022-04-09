using System;
using System.Collections.Generic;
using System.IO;
using Tech.IO.Saves;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Specific
{
    public class LoadMenuController: MonoBehaviour
    {
        [SerializeField] private UIDocument mainMenu;
        [SerializeField] private UIDocument loadMenu;

        [SerializeField] private SaveChannelSO saveChannel;

        private VisualElement root;
        
        private Button backButton;
        private ScrollView savesContainer;

        private List<SaveButtonHandler> saveButtonHandlers;

        private void Start()
        {
            root = loadMenu.rootVisualElement;

            backButton = root.Q<Button>("back_button");
            savesContainer = root.Q<ScrollView>("saves_container");
            savesContainer.Clear();

            saveButtonHandlers = new List<SaveButtonHandler>();
            GetSaves();
            
            backButton.clicked += BackButtonPressed;
        }

        private void GetSaves()
        {
            string[] paths = Directory.GetFiles(Application.persistentDataPath + "/saves");
            foreach (var path in paths)
            {
                Button button = new Button
                {
                    text = (path.Split(new []{'.','\\'}, StringSplitOptions.RemoveEmptyEntries)[^2] 
                           + " | " + File.GetLastWriteTime(path)).ToUpper()
                };
                
                SaveButtonHandler handler = new SaveButtonHandler(path, saveChannel);
                
                button.clicked += handler.ButtonPressed;
                button.clicked += ResumeTime;
                
                savesContainer.Add(button);
                saveButtonHandlers.Add(handler);
            }
        }

        private void BackButtonPressed()
        {
            mainMenu.rootVisualElement.style.display = DisplayStyle.Flex;
            loadMenu.rootVisualElement.style.display = DisplayStyle.None;
        }

        private void ResumeTime()
        {
            Time.timeScale = 1f;
        }
    }
}