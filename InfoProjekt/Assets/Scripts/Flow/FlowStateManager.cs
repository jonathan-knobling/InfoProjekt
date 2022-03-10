using Flow.States;
using UnityEngine;

namespace Flow
{
    public class FlowStateManager: MonoBehaviour
    {
        public static FlowStateManager Instance;
        
        private IFlowState state;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            state = new FlowStateDefault();
            state.EnterState();
        }

        private void Update()
        {
            state.Update();
        }

        public void ChangeState(IFlowState state)
        {
            if (state == null) return;
            this.state.LeaveState();
            this.state = state;
            this.state.EnterState();
        }
    }
}