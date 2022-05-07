using System;
using Util;

namespace Tech.IO.PlayerInput
{
    public class InputMiddleWare
    {
        public Optional<InputState> InputState { get; set; }

        public event Action OnHitButtonPressed;
        public event Action OnInteractButtonPressed;
        public event Action OnEscapeButtonPressed;
        public event Action OnSkill1ButtonPressed;

        public InputMiddleWare()
        {
            InputState = new Optional<InputState>() {enabled = false};
        }
        
        public InputState Process(InputState inputState)
        {
            //TODO skalierbar machen
            
            if (!InputState.enabled) return inputState;

            if (InputState.value.CanOperate.enabled)
            {
                if (InputState.value.InputDirection.enabled)
                {
                    return InputState.value;
                }
                return new InputState()
                {
                    CanOperate = InputState.value.CanOperate,
                    InputDirection = inputState.InputDirection
                };
            }

            if (InputState.value.InputDirection.enabled)
            {
                return new InputState()
                {
                    CanOperate = inputState.CanOperate,
                    InputDirection = InputState.value.InputDirection
                };
            }

            return inputState;
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

        public void Disable()
        {
            InputState = new Optional<InputState>() {enabled = false};
        }
    }
}