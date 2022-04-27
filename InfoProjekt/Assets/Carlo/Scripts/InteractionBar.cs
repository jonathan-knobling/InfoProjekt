using System;
using Tech;
using UI.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Util;
using Util.EventArgs;

namespace Carlo.Scripts
{
    public class InteractionBar {
        
        private readonly float interactionTime;
        private readonly EventChannelSO eventChannel;
        private readonly Timer timer;
        private readonly ProgressBar interactionBar;
        private bool active = true;

        public event Action OnProgressBarOver;
        public event Action StartEffect;
        public event Action StopEffect;

        public InteractionBar(float interactionTime, EventChannelSO eventChannel)
        {
            this.interactionTime = interactionTime;
            this.eventChannel = eventChannel;
            timer = new Timer(interactionTime);
            timer.OnElapsed += OnTimerEnd;
            interactionBar = new ProgressBar();
        }
        public InteractionBar(EventChannelSO eventChannel)
        {
            interactionTime = 1.5f;
            this.eventChannel = eventChannel;
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
                eventChannel.UIChannel.RequestRemoveUIVisualElement(interactionBar);
            } 
            else if (Input.GetKey(KeyCode.F) && !active)
            {
                StartEffect?.Invoke();
                timer.Restart();
                active = true;
                eventChannel.UIChannel.RequestAddUIVisualElement(new UIEventArgs(interactionBar, null, UIType.Default));
            }
        }

        private void OnTimerEnd()
        {
            OnProgressBarOver?.Invoke();
            eventChannel.UIChannel.RequestRemoveUIVisualElement(interactionBar);
        }
    }
}
