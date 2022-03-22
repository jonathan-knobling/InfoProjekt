using Audio;
using Flow.States;
using UnityEngine;
using Util.EventArgs;

namespace Flow
{
    public class FlowStateManager: MonoBehaviour
    {
        public static FlowStateManager Instance;
        
        //test
        [SerializeField] private AudioRequestArgs startMusicArgs;
        [SerializeField] private AudioRequestChannelSO audioRequestChannel;
        
        private IFlowState state;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            state = new FlowStateDefault();
            state.EnterState();
            
            //test
            audioRequestChannel.RequestAudio(startMusicArgs);
        }

        private void Update()
        {
            state.Update();
        }

        public void ChangeState(IFlowState flowState)
        {
            if (flowState == null) return;
            state.LeaveState();
            state = flowState;
            state.EnterState();
        }
    }
}