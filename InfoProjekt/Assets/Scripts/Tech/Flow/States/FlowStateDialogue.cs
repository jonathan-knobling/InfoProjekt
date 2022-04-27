using Tech.IO.PlayerInput;
using Actors.Player;

namespace Tech.Flow.States
{
    public class FlowStateDialogue: IFlowState
    {
        private readonly PlayerChannel playerChannel;
        private readonly InputChannel inputChannel;
        
        public FlowStateDialogue(PlayerChannel playerChannel, InputChannel inputChannel)
        {
            this.playerChannel = playerChannel;
            this.inputChannel = inputChannel;
        }

        public void EnterState()
        {
            playerChannel.MovementSetIdle();
            playerChannel.DisablePlayerMovement();
            playerChannel.DisablePlayerCombat();
            InputChannel.Enabled = false;
        }

        public void Update()
        {
            
        }

        public void LeaveState()
        {
            playerChannel.EnablePlayerCombat();
            playerChannel.EnablePlayerMovement();
            InputChannel.Enabled = true;
        }
    }
}