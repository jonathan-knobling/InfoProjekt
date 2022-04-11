using Actors.Player;
using Tech.IO;
using Tech.IO.PlayerInput;
using UnityEngine;

namespace Tech.Flow.States
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
            InputChannelSO.Enabled = false;
        }

        public void Update()
        {
            
        }

        public void LeaveState()
        {
            combatChannel.EnablePlayerCombat();
            movementChannel.EnablePlayerMovement();
            InputChannelSO.Enabled = true;
        }
    }
}