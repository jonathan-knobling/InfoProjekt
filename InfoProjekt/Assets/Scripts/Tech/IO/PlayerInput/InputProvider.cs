using System;
using System.Collections.Generic;

namespace Tech.IO.PlayerInput
{
    public class InputProvider
    {
        private readonly List<InputMiddleWare> inputMiddleWares;

        public event Action OnHitButtonPressed;
        public event Action OnInteractButtonPressed;
        public event Action OnEscapeButtonPressed;
        public event Action OnOpenInvButtonPressed;
        public event Action OnSkill1ButtonPressed;
        public event Action OnSkill2ButtonPressed;
        public event Action OnSkill3ButtonPressed;
        public event Action OnSkill4ButtonPressed;
        
        public InputProvider()
        {
            inputMiddleWares = new List<InputMiddleWare>();
        }

        public InputState GetState()
        {
            var state = new InputState();
            
            foreach (var middleWare in inputMiddleWares)
            {
                //Debug.Log(state.InputDirection.value.ToString());
                
                state = middleWare.Process(state);
            }

            return state;
        }

        public void AddMiddleWare(InputMiddleWare middleWare, int index)
        {
            if (inputMiddleWares.Contains(middleWare)) return;

            inputMiddleWares.Insert(index, middleWare);
        }

        public void RemoveMiddleWare(InputMiddleWare middleWare)
        {
            if (!inputMiddleWares.Contains(middleWare)) return;
            
            inputMiddleWares.Remove(middleWare);
            
            return;
        }

        public void HitButtonPressed()
        {
            if(GetState().CanOperate.value)
                OnHitButtonPressed?.Invoke();
        }

        public void InteractButtonPressed()
        {
            if(GetState().CanOperate.value)
                OnInteractButtonPressed?.Invoke();
        }

        public void EscapeButtonPressed()
        {
            if(GetState().CanOperate.value)
                OnEscapeButtonPressed?.Invoke();
        }

        public void OpenInvButtonPressed()
        {
            if (GetState().CanOperate.value)
                OnOpenInvButtonPressed?.Invoke();
        }

        public void Skill1ButtonPressed()
        {
            if(GetState().CanOperate.value)
                OnSkill1ButtonPressed?.Invoke();
        }
        
        public void Skill2ButtonPressed()
        {
            if(GetState().CanOperate.value)
                OnSkill2ButtonPressed?.Invoke();
        }
        
        public void Skill3ButtonPressed()
        {
            if(GetState().CanOperate.value)
                OnSkill3ButtonPressed?.Invoke();
        }
        
        public void Skill4ButtonPressed()
        {
            if(GetState().CanOperate.value)
                OnSkill4ButtonPressed?.Invoke();
        }
    }
}