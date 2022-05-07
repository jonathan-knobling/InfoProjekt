using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tech.IO.PlayerInput
{
    public class InputProvider
    {
        private readonly List<InputMiddleWare> inputMiddleWares;

        public event Action OnHitButtonPressed;
        public event Action OnInteractButtonPressed;
        public event Action OnEscapeButtonPressed;
        public event Action OnSkill1ButtonPressed;
        
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

        public bool AddMiddleWare(InputMiddleWare middleWare, int index)
        {
            if (inputMiddleWares.Contains(middleWare)) return false;

            inputMiddleWares.Insert(index, middleWare);

            middleWare.OnEscapeButtonPressed += EscapeButtonPressed;
            middleWare.OnHitButtonPressed += HitButtonPressed;
            middleWare.OnInteractButtonPressed += InteractButtonPressed;
            middleWare.OnSkill1ButtonPressed += Skill1ButtonPressed;
            
            return true;
        }

        public bool RemoveMiddleWare(InputMiddleWare middleWare)
        {
            if (!inputMiddleWares.Contains(middleWare)) return false;
            
            middleWare.OnEscapeButtonPressed -= EscapeButtonPressed;
            middleWare.OnHitButtonPressed -= HitButtonPressed;
            middleWare.OnSkill1ButtonPressed -= Skill1ButtonPressed;
            middleWare.OnInteractButtonPressed -= InteractButtonPressed;
            
            inputMiddleWares.Remove(middleWare);
            
            return true;
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

        public void Skill1ButtonPressed()
        {
            if(GetState().CanOperate.value)
                OnSkill1ButtonPressed?.Invoke();
        }
    }
}