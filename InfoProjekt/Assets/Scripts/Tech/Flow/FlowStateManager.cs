using Tech.Flow.States;
using UnityEngine;

namespace Tech.Flow
{
    public class FlowStateManager: MonoBehaviour
    {
        [SerializeField] private EventChannelSO eventChannel;
        
        private IFlowState state;

        private void Start()
        {
            state = new FlowStateDefault();
            state.EnterState();

            eventChannel.FlowChannel.OnChangeFlowState += ChangeState;
        }

        private void Update()
        {
            state.Update();
        }

        private void ChangeState(IFlowState flowState)
        {
            if (flowState == null) return;
            state.LeaveState();
            state = flowState;
            state.EnterState();
        }
    }
}