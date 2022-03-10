using UnityEngine;

namespace Flow.States
{
    public class FlowStatePaused: IFlowState
    {
        public void EnterState()
        {
            Debug.Log("time 0");
            Time.timeScale = 0;
        }

        public void Update()
        {
            
        }

        public void LeaveState()
        {
            Debug.Log("time 1");
            Time.timeScale = 1;
        }
    }
}