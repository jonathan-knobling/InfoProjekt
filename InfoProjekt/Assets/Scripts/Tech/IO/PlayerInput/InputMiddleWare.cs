using System.ComponentModel;
using Util;

namespace Tech.IO.PlayerInput
{
    public class InputMiddleWare
    {
        public Optional<InputState> InputState { get; set; }

        [Description("Creates InputState and sets it to disabled")]
        public InputMiddleWare()
        {
            InputState = new Optional<InputState> { enabled = false };
        }
        
        public InputState Process(InputState inputState)
        {
            InputState newState = new InputState();

            //InputDirection
            if (InputState.enabled && InputState.value.InputDirection.enabled)
                newState.InputDirection = InputState.value.InputDirection;
            else newState.InputDirection.value = inputState.InputDirection.value;
            
            //CanOperate
            if (InputState.enabled && InputState.value.CanOperate.enabled)
                newState.CanOperate = InputState.value.CanOperate;
            else newState.CanOperate.value = inputState.CanOperate.value;
            
            //DontCapVelocity
            if (InputState.enabled && InputState.value.DontCapVelocity.enabled)
                newState.DontCapVelocity = InputState.value.DontCapVelocity;
            else newState.DontCapVelocity.value = inputState.DontCapVelocity.value;
            
            //LinearDrag
            if (InputState.enabled && InputState.value.LinearDrag.enabled)
                newState.LinearDrag = InputState.value.LinearDrag;
            else newState.LinearDrag.value = inputState.LinearDrag.value;
            
            return newState;
        }

        public void Disable()
        {
            InputState = new Optional<InputState> { enabled = false };
        }
    }
}