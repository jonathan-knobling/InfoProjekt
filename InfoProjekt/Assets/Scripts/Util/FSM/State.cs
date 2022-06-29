namespace Util.FSM
{
    public abstract class State
    {
        protected StateTransition[] Transitions;

        public void Init(StateTransition[] transitions)
        {
            Transitions = transitions;
        }

        public abstract void OnStateEnter();
        public abstract void OnStateExit();
        public abstract void OnStateUpdate();
    }
}