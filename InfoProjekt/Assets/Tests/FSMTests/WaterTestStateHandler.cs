using UnityEngine;
using Util.FSM;
using Util.FSM.TransitionConditions;

namespace Tests.FSMTests
{
    public class WaterTestStateHandler: IStateHandler
    {
        private State state;

        public string CurState = "";
        public string LastState = "";

        public WaterTestStateHandler(TestTemperature temp)
        {
            bool IsBelowZero() => temp.Temp < 0;
            bool IsNormal() => temp.Temp is >= 0 and < 100;
            bool IsOverHundred() => temp.Temp > 100;

            var gasState = new GasState(this);
            var frozenState = new FrozenState(this);
            var liquidState = new LiquidState(this);
            
            frozenState.Init(new[]
            {
                new StateTransition(this, liquidState, new ITransitionCondition[]
                {
                    new EventTransitionCondition(IsNormal)
                }),
                new StateTransition(this, gasState, new ITransitionCondition[]
                {
                    new EventTransitionCondition(IsOverHundred)
                })
            });
            
            gasState.Init(new []
            {
                new StateTransition(this, frozenState, new ITransitionCondition[]
                {
                    new EventTransitionCondition(IsBelowZero)
                }),
                new StateTransition(this, liquidState, new ITransitionCondition[]
                {
                    new EventTransitionCondition(IsNormal)
                })
            });
            
            liquidState.Init(new[]
            {
                new StateTransition(this, frozenState, new ITransitionCondition[]
                {
                    new EventTransitionCondition(IsBelowZero)
                }),
                new StateTransition(this, gasState, new ITransitionCondition[]
                {
                    new EventTransitionCondition(IsOverHundred)
                })
            });

            state = liquidState;
            state.OnStateEnter();
        }

        public void Update()
        {
            state.OnStateUpdate();
        }
        
        public void ChangeState(State newState)
        {
            state = newState;
        }

        public State GetState()
        {
            return state;
        }
    }

    public class TestTemperature
    {
        public float Temp;
    }
}