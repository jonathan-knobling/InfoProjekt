using Util.FSM;

namespace Tests.FSMTests
{
    public class LiquidState: State
    {
        private WaterTestStateHandler handler;

        public LiquidState(WaterTestStateHandler handler)
        {
            this.handler = handler;
        }
        
        public override void OnStateEnter()
        {
            handler.CurState = "liquid";
        }

        public override void OnStateExit()
        {
            handler.LastState = "liquid";
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