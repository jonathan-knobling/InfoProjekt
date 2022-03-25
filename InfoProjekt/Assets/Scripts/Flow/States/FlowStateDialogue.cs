using IO;
using Player;

namespace Flow.States
{
    public class FlowStateDialogue: IFlowState
    {
        private readonly PlayerCombatChannelSO combatChannel;
        private readonly PlayerMovementChannelSO movementChannel;
        private readonly InputChannelSO inputChannel;
        
        public FlowStateDialogue(PlayerCombatChannelSO combatChannel, PlayerMovementChannelSO movementChannel, InputChannelSO inputChannel)
        {
            this.combatChannel = combatChannel;
            this.movementChannel = movementChannel;
            this.inputChannel = inputChannel;
        }

        public void EnterState()
        {
            movementChannel.SetIdle();
            movementChannel.DisablePlayerMovement();
            combatChannel.DisablePlayerCombat();
            inputChannel.enabled = false;
        }

        public void Update()
        {
            
        }

        public void LeaveState()
        {
            combatChannel.EnablePlayerCombat();
            movementChannel.EnablePlayerMovement();
            inputChannel.enabled = true;
        }
    }
}