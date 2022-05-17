using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Util.FSM;
using Util.FSM.TransitionConditions;

namespace Actors.Enemies.EnemyAI
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class EnemyStateHandler: MonoBehaviour, IStateHandler
    {
        private State state;

        private EnemyRoamingState roamingState;
        private EnemyAttackingState attackingState;

        private CircleCollider2D circleCollider2D;

        [SerializeField] private GameObject target;
        
        private void Start()
        {
            circleCollider2D = GetComponent<CircleCollider2D>();
            var targetCollider = target.GetComponent<Collider2D>();
            
            bool RoamToAttackCondition() => circleCollider2D.IsTouching(targetCollider);
            bool AttackToRoamCondition() => !circleCollider2D.IsTouching(targetCollider);
            
            var go = gameObject;
            roamingState = new EnemyRoamingState(go);
            attackingState = new EnemyAttackingState(go);
            
            roamingState.Init(StateTransition.SingleTransition(
                this, attackingState,
                EventTransitionCondition.SingleCondition(RoamToAttackCondition)));
            
            attackingState.Init(StateTransition.SingleTransition(
                this, roamingState,
                EventTransitionCondition.SingleCondition(AttackToRoamCondition)));

            state = roamingState;
        }

        private void Update()
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