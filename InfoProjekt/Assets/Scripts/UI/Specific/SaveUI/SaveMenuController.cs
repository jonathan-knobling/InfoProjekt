using System;
using System.Collections.Generic;
using System.IO;
using Tech.IO.Saves;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Specific.SaveUI
{
    public class SaveMenuController: MonoBehaviour
    {
        [SerializeField] private UIDocument pauseMenu;
        [SerializeField] private UIDocument saveMenu;
        [SerializeField] private IOChannelSO ioChannel;
        
        private VisualElement root;
        
        private Button backButton;
        private ScrollView savesContainer;

        //ReSharper disable once CollectionNeverQueried.Local
        private List<SaveButtonHandler> saveButtonHandlers;

        private void Start()
        {
            root = saveMenu.rootVisualElement;

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
                
                SaveButtonHandler handler = new SaveButtonHandler(path, ioChannel);
                
                button.clicked += handler.ButtonPressed;
                
                savesContainer.Add(button);
                saveButtonHandlers.Add(handler);
            }
        }

        private void BackButtonPressed()
        {
            saveMenu.enabled = false;
            pauseMenu.enabled = true;
        }
    }
}