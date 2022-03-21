using System;
using UnityEngine;

namespace IO
{
    [CreateAssetMenu(menuName = "Channels/Input Channel")]
    public class InputChannelSO: ScriptableObject
    {
        public float horizontalDirection;
        
        public event Action JumpButtonPressed;
        public event Action HitButtonPressed;
        public event Action InteractButtonPressed;
        public event Action PauseButtonPressed;
        public event Action Skill1ButtonPressed;

        public void OnJumpButtonPressed()
        {
            JumpButtonPressed?.Invoke();
        }

        public void OnHitButtonPressed()
        {
            HitButtonPressed?.Invoke();
        }

        public void OnInteractButtonPressed()
        {
            InteractButtonPressed?.Invoke();
        }

        public void OnPauseButtonPressed()
        {
            PauseButtonPressed?.Invoke();
        }

        public void OnSkill1ButtonPressed()
        {
            Skill1ButtonPressed?.Invoke();
        }
    }
}