using System.Linq;
using JetBrains.Annotations;

namespace Util.FSM
{
    public abstract class StateTransition
    {
        [NotNull] private readonly IStateHandler stateHandler;
        [NotNull] private readonly State targetState;

        [NotNull] private readonly ITransitionCondition[] conditions;

        public StateTransition([NotNull] IStateHandler stateHandler, [NotNull] State targetState, [NotNull] ITransitionCondition[] conditions)
        {
            this.stateHandler = stateHandler;
            this.targetState = targetState;
            this.conditions = conditions;
        }

        public void Update()
        {
            //if a condition isnt met return
            if (conditions.Any(condition => !condition.IsMet()))
            {
                return;
            }

            //if every condition is met execute Transition
            Transition();
        }

        private void Transition()
        {
            stateHandler.GetState().OnStateExit();
            stateHandler.ChangeState(targetState);
            stateHandler.GetState().OnStateEnter();
        }
    }
}