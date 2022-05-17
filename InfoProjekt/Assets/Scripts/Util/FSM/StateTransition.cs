using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Util.FSM
{
    public class StateTransition
    {
        private readonly IStateHandler stateHandler;
        private readonly State targetState;

        private readonly ITransitionCondition[] conditions;

        public StateTransition(IStateHandler stateHandler, State targetState, ITransitionCondition[] conditions)
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

        public static StateTransition[] SingleTransition(IStateHandler stateHandler, State targetState, ITransitionCondition[] conditions)
        {
            var arr = new StateTransition[1];
            arr[0] = new StateTransition(stateHandler, targetState, conditions);
            return arr;
        }
    }
}