using Flow.States;
using UnityEngine;

namespace Flow
{
    public class FlowStateManager: MonoBehaviour
    {
        [SerializeField] private FlowChannelSO flowChannel;
        
        private IFlowState state;

        private void Start()
        {
            state = new FlowStateDefault();
            state.EnterState();

            flowChannel.OnChangeFlowState += ChangeState;
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