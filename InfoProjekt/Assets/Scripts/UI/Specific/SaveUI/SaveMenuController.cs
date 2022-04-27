using System;
using System.Collections.Generic;
using System.IO;
using Tech;
using Tech.IO.Saves;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Specific.SaveUI
{
    public class SaveMenuController: MonoBehaviour
    {
        [SerializeField] private UIDocument pauseMenu;
        [SerializeField] private UIDocument saveMenu;
        [SerializeField] private EventChannelSO eventChannel;
        
        private VisualElement root;
        
        private Button backButton;
        private Button newSaveButton;
        
        private ScrollView savesContainer;

        //ReSharper disable once CollectionNeverQueried.Local
        private List<SaveButtonHandler> saveButtonHandlers;

        private void Start()
        {
            root = saveMenu.rootVisualElement;

            backButton = root.Q<Button>("back_button");
            newSaveButton = root.Q<Button>("new_save");
            
            savesContainer = root.Q<ScrollView>("saves_container");
            savesContainer.Clear();

            saveButtonHandlers = new List<SaveButtonHandler>();
            GetSaves();
            
            backButton.clicked += BackButtonPressed;
            newSaveButton.clicked += NewSaveButtonPressed;
            
            
        }

        private void NewSaveButtonPressed()
        {
            eventChannel.IOChannel.SaveToFile(SaveIO.GenerateNewFileName());
        }

        private void GetSaves()
        {
            string[] paths = Directory.GetFiles(Application.persistentDataPath + "/saves");
            foreach (var path in paths)
            {
                string fileName = path.Split(new[] {'.', '\\'}, StringSplitOptions.RemoveEmptyEntries)[^2]
                                   + " | " + File.GetLastWriteTime(path);
                Button button = new Button
                {
                    text = fileName.ToUpper()
                };
                
                SaveButtonHandler handler = new SaveButtonHandler(fileName, eventChannel);
                
                button.clicked += handler.ButtonPressed;
                
                savesContainer.Add(button);
                saveButtonHandlers.Add(handler);
            }
        }

        private void BackButtonPressed()
        {
            saveMenu.enabled = false;
            pauseMenu.rootVisualElement.style.display = DisplayStyle.Flex;
        }
    }
}