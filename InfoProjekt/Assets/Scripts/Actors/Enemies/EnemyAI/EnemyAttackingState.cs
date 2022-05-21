using UnityEngine;
using Util.FSM;

namespace Actors.Enemies.EnemyAI
{
    public class EnemyAttackingState: State
    {
        private readonly GameObject enemy;
        private readonly EnemyMovementController movementController;

        public EnemyAttackingState(GameObject enemy, EnemyMovementController enemyMovementController)
        {
            this.enemy = enemy;
            movementController = enemyMovementController;
        }
        
        public override void OnStateEnter()
        {
            enemy.GetComponent<SpriteRenderer>().color = Color.red;
        }

        public override void OnStateExit()
        {
            
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