using Util.FSM;

namespace Tests.FSMTests
{
    public class FrozenState: State
    {
        private WaterTestStateHandler handler;

        public FrozenState(WaterTestStateHandler handler)
        {
            this.handler = handler;
        }
        
        public override void OnStateEnter()
        {
            handler.CurState = "frozen";
        }

        public override void OnStateExit()
        {
            handler.LastState = "frozen";
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