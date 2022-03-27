using System;
using UnityEngine;

namespace Tech.IO
{
    [CreateAssetMenu(menuName = "Channels/Input Channel")]
    public class InputChannelSO: ScriptableObject
    {
        public float HorizontalDirection { set; get; }
        public static bool Enabled { get; set; }
        
        public event Action OnJumpButtonPressed;
        public event Action OnHitButtonPressed;
        public event Action OnInteractButtonPressed;
        public event Action OnPauseButtonPressed;
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
                Debug.Log("Invoke Jump");
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

        public void PauseButtonPressed()
        {
            if (Enabled)
            {
                OnPauseButtonPressed?.Invoke();
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