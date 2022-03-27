using System;
using UnityEngine;

namespace Tech.IO
{
    [CreateAssetMenu(menuName = "Channels/Input Channel")]
    public class InputChannelSO: ScriptableObject
    {
        public float HorizontalDirection { set; get; }
        public bool enabled = true;
        
        public event Action OnJumpButtonPressed;
        public event Action OnHitButtonPressed;
        public event Action OnInteractButtonPressed;
        public event Action OnPauseButtonPressed;
        public event Action OnSkill1ButtonPressed;

        public void JumpButtonPressed()
        {
            Debug.Log(enabled);
            if (enabled)
            {
                Debug.Log("Invoke Jump");
                OnJumpButtonPressed?.Invoke();
            }
        }

        public void HitButtonPressed()
        {
            if (enabled)
            {
                OnHitButtonPressed?.Invoke();
            }
        }

        public void InteractButtonPressed()
        {
            if (enabled)
            {
                OnInteractButtonPressed?.Invoke();
            }
        }

        public void PauseButtonPressed()
        {
            if (enabled)
            {
                OnPauseButtonPressed?.Invoke();
            }
        }

        public void Skill1ButtonPressed()
        {
            if (enabled)
            {
                OnSkill1ButtonPressed?.Invoke();
            }
        }
    }
}