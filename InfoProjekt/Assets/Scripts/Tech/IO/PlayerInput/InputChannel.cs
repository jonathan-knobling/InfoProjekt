using System;
using UnityEngine;

namespace Tech.IO.PlayerInput
{
    public class InputChannel
    {
        public Vector2 InputDirection { set; get; }
        public static bool Enabled { get; set; }
        
        public event Action OnJumpButtonPressed;
        public event Action OnHitButtonPressed;
        public event Action OnInteractButtonPressed;
        public event Action OnEscapeButtonPressed;
        public event Action OnSkill1ButtonPressed;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Init()
        {
            Enabled = true;
        }
        
        public void JumpButtonPressed()
        {
            Debug.Log(Enabled);
            if (Enabled)
            {
                OnJumpButtonPressed?.Invoke();
            }
        }

        public void HitButtonPressed()
        {
            if (Enabled)
            {
                OnHitButtonPressed?.Invoke();
            }
        }

        public void InteractButtonPressed()
        {
            if (Enabled)
            {
                OnInteractButtonPressed?.Invoke();
            }
        }

        public void EscapeButtonPressed()
        {
            if (Enabled)
            {
                OnEscapeButtonPressed?.Invoke();
            }
        }

        public void Skill1ButtonPressed()
        {
            if (Enabled)
            {
                OnSkill1ButtonPressed?.Invoke();
            }
        }
    }
}