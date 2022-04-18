using System;
using UI.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using Util;
using Util.EventArgs;

namespace Assets.Carlo.Scripts
{
    public class InteractionBar {
    
        private float interactionTime;
        private UIChannelSO uiChannel;
        private Timer timer;
        private ProgressBar interactionBar;
        private bool active = true;

        public event Action OnProgressBarOver;
        public event Action StartEffect;
        public event Action StopEffect;

        public InteractionBar(float interactionTime, UIChannelSO uiChannel)
        {
            this.interactionTime = interactionTime;
            this.uiChannel = uiChannel;
            timer = new Timer(interactionTime);
            timer.OnElapsed += OnTimerEnd;
            interactionBar = new ProgressBar();
        }
        public InteractionBar(UIChannelSO uiChannel)
        {
            interactionTime = 1.5f;
            this.uiChannel = uiChannel;
            timer = new Timer(interactionTime);
            timer.OnElapsed += OnTimerEnd;
            interactionBar = new ProgressBar();
        }

        public void Update()
        {
            timer.Update();
            interactionBar.value = timer.ElapsedTime / interactionTime * 100;
            
            if (!Input.GetKey(KeyCode.F) && active)
            {
                StopEffect?.Invoke();
                timer.Pause();
                active = false;
                uiChannel.RequestRemoveUIVisualElement(interactionBar);
            } 
            else if (Input.GetKey(KeyCode.F) && !active)
            {
                StartEffect?.Invoke();
                timer.Restart();
                active = true;
                uiChannel.RequestAddUIVisualElement(new UIEventArgs(interactionBar, null, UIType.Default));
            }
        }

        private void OnTimerEnd()
        {
            OnProgressBarOver?.Invoke();
            uiChannel.RequestRemoveUIVisualElement(interactionBar);
        }
    }
}
