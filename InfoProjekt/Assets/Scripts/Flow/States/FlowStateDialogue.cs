using IO;
using Player;

namespace Flow.States
{
    public class FlowStateDialogue: IFlowState
    {
        public void EnterState()
        {
            PlayerMovementController.Instance.SetIdle();
            PlayerMovementController.Instance.enabled = false;
            PlayerCombatController.Instance.enabled = false;
            PlayerInput.Instance.enabled = false;
        }

        public void Update()
        {
            
        }

        public void LeaveState()
        {
            PlayerCombatController.Instance.enabled = true;
            PlayerMovementController.Instance.enabled = true;
            PlayerInput.Instance.enabled = true;
        }
    }
}