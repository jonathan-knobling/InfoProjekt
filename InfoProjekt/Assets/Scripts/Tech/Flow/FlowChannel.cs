using System;
using Actors.Player;
using Tech.Flow.States;
using Tech.IO.PlayerInput;

namespace Tech.Flow
{
    public class FlowChannel
    {
        private readonly PlayerChannel playerChannel;
        private readonly InputChannel inputChannel;

        private readonly FlowStateDefault defaultState;
        private readonly FlowStatePaused pausedState;
        private FlowStateDialogue dialogueState;

        public event Action<IFlowState> OnChangeFlowState;

        public FlowChannel(PlayerChannel playerChannel, InputChannel inputChannel)
        {
            this.playerChannel = playerChannel;
            this.inputChannel = inputChannel;
            
            defaultState = new FlowStateDefault();
            pausedState = new FlowStatePaused();
        }

        public void ChangeFlowState(FlowState state)
        {
            switch (state)
            {
                case FlowState.Default:
                {
                    OnChangeFlowState?.Invoke(defaultState);
                    break;
                }
                case FlowState.Paused:
                {
                    OnChangeFlowState?.Invoke(pausedState);
                    break;
                }
                case FlowState.Dialogue:
                {
                    dialogueState ??= new FlowStateDialogue(inputChannel);
                    OnChangeFlowState?.Invoke(dialogueState);
                    break;
                }
            }
        }
    }
}