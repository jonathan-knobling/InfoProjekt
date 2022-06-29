using UnityEngine;
using Util.FSM;
using Util.FSM.TransitionConditions;

namespace Actors.Enemies.EnemyAI
{
    public class EnemyStateHandler: IStateHandler
    {
        private State state;

        public EnemyStateHandler(GameObject enemy, GameObject target, EnemyMovementController enemyMovementController)
        {
            //Get Enemy and Target Colliders
            var enemyCollider = enemy.GetComponent<CircleCollider2D>();
            var targetCollider = target.GetComponent<Collider2D>();

            //Transition Condition Functions
            bool RoamToAttackCondition() => enemyCollider.IsTouching(targetCollider);
            bool AttackToRoamCondition() => !enemyCollider.IsTouching(targetCollider);
            
            //Create Enemy States
            var roamingState = new EnemyRoamingState(enemy, target, enemyMovementController);
            var attackingState = new EnemyAttackingState(enemy, target, enemyMovementController);
            
            //Setup State Transitions
            roamingState.Init(StateTransition.SingleTransition(
                this, attackingState,
                EventTransitionCondition.SingleCondition(RoamToAttackCondition)));
            
            attackingState.Init(StateTransition.SingleTransition(
                this, roamingState,
                EventTransitionCondition.SingleCondition(AttackToRoamCondition)));

            //Set Starting State to Roaming State
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