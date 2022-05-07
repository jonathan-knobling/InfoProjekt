using System;
using UnityEngine;

namespace Tech.IO.PlayerInput
{
    public class InputChannel
    {
        public InputProvider InputProvider;

        public event Action OnHitButtonPressed;
        public event Action OnInteractButtonPressed;
        public event Action OnEscapeButtonPressed;
        public event Action OnSkill1ButtonPressed;
        
        public InputChannel()
        {
            InputProvider = new InputProvider();

            InputProvider.OnHitButtonPressed += HitButtonPressed;
            InputProvider.OnInteractButtonPressed += InteractButtonPressed;
            InputProvider.OnEscapeButtonPressed += EscapeButtonPressed;
            InputProvider.OnSkill1ButtonPressed += Skill1ButtonPressed;
        }

        public void HitButtonPressed()
        {
            OnHitButtonPressed?.Invoke();
        }

        public void InteractButtonPressed()
        {
            OnInteractButtonPressed?.Invoke();
        }

        public void EscapeButtonPressed()
        {
            OnEscapeButtonPressed?.Invoke();
        }

        public void Skill1ButtonPressed()
        {
            OnSkill1ButtonPressed?.Invoke();
        }
    }
}