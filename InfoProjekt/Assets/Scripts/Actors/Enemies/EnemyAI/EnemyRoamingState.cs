using UnityEngine;
using Util;
using Util.FSM;

namespace Actors.Enemies.EnemyAI
{
    public class EnemyRoamingState: State
    {
        private readonly GameObject enemy;
        private readonly EnemyMovementController movementController;
        
        private Timer idleTimer;
        
        private Rigidbody2D rb;
        
        public EnemyRoamingState(GameObject enemy, GameObject target, EnemyMovementController enemyMovementController)
        {
            this.enemy = enemy;
            movementController = enemyMovementController;
        }
        
        public override void OnStateEnter()
        {
            enemy.GetComponent<SpriteRenderer>().color = Color.green;
            idleTimer = new Timer(Random.value);
            idleTimer.OnElapsed += OnTimerOver;
        }
        
        public override void OnStateExit()
        {
            
        }
        
        public override void OnStateUpdate()
        {
            //update transitions
            foreach (var transition in Transitions)
            {
                transition.Update();
            }
        }
        
        private void OnTimerOver()
        {
            var dir = Random.insideUnitCircle;
            movementController.Move(dir.magnitude < 0.3f ? Vector2.zero : dir);
        }
    }
}