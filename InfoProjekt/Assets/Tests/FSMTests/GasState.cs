using Util.FSM;

namespace Tests.FSMTests
{
    public class GasState: State
    {
        private WaterTestStateHandler handler;

        public GasState(WaterTestStateHandler handler)
        {
            this.handler = handler;
        }
        
        public override void OnStateEnter()
        {
            handler.CurState = "gas";
        }

        public override void OnStateExit()
        {
            handler.LastState = "gas";
        }

        public override void OnStateUpdate()
        {
            foreach (var transition in Transitions)
            {
                transition.Update();
            }
        }
    }
}