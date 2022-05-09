using System;
using UnityEngine;

namespace Util
{
    [Serializable]
    public class Timer
    {
        private readonly float time;
        private float elapsedTime;
        private bool elapsed;
        private bool paused;
        private bool repeat;

        public event Action OnElapsed;

        //getter
        public bool Elapsed => elapsed;
        public bool Paused => paused;
        public bool Repeat => repeat;
        public float ElapsedTime => elapsedTime;
        public float RemainingTime => time - elapsedTime;
        
        public Timer(float time, bool repeat)
        {
            this.repeat = repeat;
            elapsed = false;
            this.time = time;
        }
        
        public Timer(float time)
        {
            repeat = false;
            elapsed = false;
            this.time = time;
        }

        public void Update()
        {
            if (!paused)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= time)
                {
                    if (!repeat)
                    {
                        paused = true;
                    }
                    elapsed = true;
                    OnElapsed?.Invoke();
                }   
            }
        }

        public void Pause()
        {
            paused = true;
        }

        public void Resume()
        {
            paused = false;
        }

        public void Restart()
        {
            elapsedTime = 0;
            elapsed = false;
            paused = false;
        }

        public void SetRepeat(bool b)
        {
            repeat = b;
        }

        public void SetRemainingTime(float remainingTime)
        {
            if (remainingTime < 0 || remainingTime > time) return;

            elapsedTime = time - remainingTime;
        }
    }
}