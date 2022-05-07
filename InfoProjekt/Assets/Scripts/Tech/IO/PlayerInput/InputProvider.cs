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
                state = middleWare.Process(state);
            }

            Debug.Log(state.InputDirection.value.ToString());
            return state;
        }

        public bool AddMiddleWare(InputMiddleWare middleWare, int index)
        {
            if (inputMiddleWares.Contains(middleWare)) return false;

            inputMiddleWares.Insert(index, middleWare);

            middleWare.OnEscapeButtonPressed += OnEscapeButtonPressed;
            middleWare.OnHitButtonPressed += OnHitButtonPressed;
            middleWare.OnInteractButtonPressed += OnInteractButtonPressed;
            middleWare.OnSkill1ButtonPressed += OnSkill1ButtonPressed;
            
            return true;
        }

        public bool RemoveMiddleWare(InputMiddleWare middleWare)
        {
            if (!inputMiddleWares.Contains(middleWare)) return false;
            
            middleWare.OnEscapeButtonPressed -= OnEscapeButtonPressed;
            middleWare.OnHitButtonPressed -= OnHitButtonPressed;
            middleWare.OnSkill1ButtonPressed -= OnSkill1ButtonPressed;
            middleWare.OnInteractButtonPressed -= OnInteractButtonPressed;
            
            inputMiddleWares.Remove(middleWare);
            
            return true;
        }
    }
}