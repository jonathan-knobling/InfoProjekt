using System.Collections.Generic;

namespace Util.FSM
{
    public abstract class State
    {
        public abstract void OnStateEnter();
        public abstract void OnStateExit();
        public abstract void OnStateUpdate();

        protected List<StateTransition> transitions;
    }
}