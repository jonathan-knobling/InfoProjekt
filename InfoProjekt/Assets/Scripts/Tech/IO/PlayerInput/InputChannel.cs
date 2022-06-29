using System;
using System.ComponentModel;
using UnityEngine;

namespace Tech.IO.PlayerInput
{
    public class InputChannel
    {
        public readonly InputProvider InputProvider;

        [Description("Mouse 0 Button")] public event Action OnHitButtonPressed;
        [Description("F Button")] public event Action OnInteractButtonPressed;
        [Description("Escape Button")] public event Action OnEscapeButtonPressed;
        [Description("TAB Button")] public event Action OnOpenInvButtonPressed;
        [Description("E Button")] public event Action OnSkill1ButtonPressed;
        [Description("Q Button")] public event Action OnSkill2ButtonPressed;
        [Description("R Button")] public event Action OnSkill3ButtonPressed;
        [Description("Space Button")] public event Action OnSkill4ButtonPressed;
        
        public InputChannel()
        {
            InputProvider = new InputProvider();

            InputProvider.OnHitButtonPressed += HitButtonPressed;
            InputProvider.OnInteractButtonPressed += InteractButtonPressed;
            InputProvider.OnEscapeButtonPressed += EscapeButtonPressed;
            InputProvider.OnOpenInvButtonPressed += OpenInvButtonPressed;
            InputProvider.OnSkill1ButtonPressed += Skill1ButtonPressed;
            InputProvider.OnSkill2ButtonPressed += Skill2ButtonPressed;
            InputProvider.OnSkill3ButtonPressed += Skill3ButtonPressed;
            InputProvider.OnSkill4ButtonPressed += Skill4ButtonPressed;
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

        public void OpenInvButtonPressed()
        {
            OnOpenInvButtonPressed?.Invoke();
        }

        public void Skill1ButtonPressed()
        {
            OnSkill1ButtonPressed?.Invoke();
        }
        
        public void Skill2ButtonPressed()
        {
            OnSkill2ButtonPressed?.Invoke();
        }
        
        public void Skill3ButtonPressed()
        {
            OnSkill3ButtonPressed?.Invoke();
        }
        
        public void Skill4ButtonPressed()
        {
            OnSkill4ButtonPressed?.Invoke();
        }
    }
}