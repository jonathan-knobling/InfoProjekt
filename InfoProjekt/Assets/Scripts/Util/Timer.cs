using System;
using UnityEngine;

namespace Util
{
    public class Timer
    {

        private float time;
        private float elapsedTime;
        public event EventHandler OnElapsed;
        public bool elapsed;
        private bool paused;

        public Timer(float time)
        {
            this.time = time;
            elapsed = false;
        }

        public void Update()
        {
            if (!paused)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= time)
                {
                    elapsed = true;
                    OnElapsed?.Invoke(this, System.EventArgs.Empty);
                }   
            }
        }

        private void Reset()
        {
            elapsedTime = 0;
            elapsed = false;
        }

        private void Pause()
        {
            paused = true;
        }
    }
}