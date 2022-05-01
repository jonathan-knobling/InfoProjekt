using System;
using System.Collections.Generic;
using System.IO;
using Tech.IO.Saves;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Specific.SaveUI
{
    public class LoadMenuController: MonoBehaviour
    {
        [SerializeField] private UIDocument mainMenu;
        [SerializeField] private UIDocument loadMenu;

        [SerializeField] private IOChannelSO ioChannel;

        private VisualElement root;
        
        private Button backButton;
        private ScrollView savesContainer;

        //ReSharper disable once CollectionNeverQueried.Local
        private List<LoadButtonHandler> loadButtonHandlers;

        private void Start()
        {
            root = loadMenu.rootVisualElement;

            backButton = root.Q<Button>("back_button");
            savesContainer = root.Q<ScrollView>("saves_container");
            savesContainer.Clear();

            loadButtonHandlers = new List<LoadButtonHandler>();
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
                
                LoadButtonHandler handler = new LoadButtonHandler(path, ioChannel);
                
                button.clicked += handler.ButtonPressed;
                button.clicked += ResumeTime;
                
                savesContainer.Add(button);
                loadButtonHandlers.Add(handler);
            }
        }

        private void BackButtonPressed()
        {
            mainMenu.enabled = true;
            loadMenu.enabled = false;
        }

        private void ResumeTime()
        {
            Time.timeScale = 1f;
        }
    }
}