using Tech.IO.PlayerInput;
using Actors.Player;
using UnityEngine;
using Util;

namespace Tech.Flow.States
{
    public class FlowStateDialogue: IFlowState
    {
        private InputMiddleWare inputMiddleWare;
        
        public FlowStateDialogue(InputChannel inputChannel)
        {
            inputMiddleWare = new InputMiddleWare();
            inputChannel.InputProvider.AddMiddleWare(inputMiddleWare, 1);
        }

        public void EnterState()
        {
            inputMiddleWare.InputState = new Optional<InputState>()
            {
                enabled = true,
                value = new InputState(new Vector2(0, 0), false)
            };
        }

        public void Update()
        {
            
        }

        public void LeaveState()
        {
            inputMiddleWare.Disable();
        }
    }
}