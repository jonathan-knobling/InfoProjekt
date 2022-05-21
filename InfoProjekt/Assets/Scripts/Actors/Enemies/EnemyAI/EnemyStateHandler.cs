using UnityEngine;
using Util.FSM;
using Util.FSM.TransitionConditions;

namespace Actors.Enemies.EnemyAI
{
    public class EnemyStateHandler: IStateHandler
    {
        private State state;

        public EnemyStateHandler(GameObject go, GameObject target, EnemyMovementController enemyMovementController)
        {
            //Setup State Machine Transitions
            var circleCollider2D = go.GetComponent<CircleCollider2D>();
            var targetCollider = target.GetComponent<Collider2D>();

            bool RoamToAttackCondition() => circleCollider2D.IsTouching(targetCollider);
            bool AttackToRoamCondition() => !circleCollider2D.IsTouching(targetCollider);
            
            var roamingState = new EnemyRoamingState(go, enemyMovementController);
            var attackingState = new EnemyAttackingState(go, enemyMovementController);
            
            roamingState.Init(StateTransition.SingleTransition(
                this, attackingState,
                EventTransitionCondition.SingleCondition(RoamToAttackCondition)));
            
            attackingState.Init(StateTransition.SingleTransition(
                this, roamingState,
                EventTransitionCondition.SingleCondition(AttackToRoamCondition)));

            state = roamingState;
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
}