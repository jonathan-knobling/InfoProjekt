using Unity.Mathematics;
using UnityEngine;
using Util;
using Random = UnityEngine.Random;

namespace Enemies.EnemyAI
{
    public class EnemyRoamingState : EnemyState
    {

        private Vector2 startPosition;
        private Timer actionTimer;

        public EnemyRoamingState()
        {
            // idle time after spawn
            actionTimer = new Timer(1.5f);
        }
    
        public override void EnterState(EnemyAI enemyAI, EnemyStats stats)
        {
            this.startPosition = enemyAI.getStartingPosition();
        }

        public override void Update(EnemyAI enemyAI, EnemyStats stats)
        {
            //change enemy actions with random timer
            if (actionTimer == null || actionTimer.elapsed == true)
            {
                actionTimer = new Timer(Random.Range(1.5f, 0.3f));
                PerformRandomAction(enemyAI, stats);
            }
            actionTimer.Update();
        
            Collider2D collider = enemyAI.checkView();
            if (collider != null)
            {
                enemyAI.changeState();
                enemyAI.setTarget(collider.GetComponent<GameObject>());
            }
        }

        private void PerformRandomAction(EnemyAI enemyAI, EnemyStats stats)
        {
            if (Random.value > 0.5f) //idle action
            {
                enemyAI.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            else
            {
                EnemyMovementController movementController = enemyAI.GetComponent<EnemyMovementController>();
                float roamingRadius = enemyAI.GetRoamingRadius();
                float relativeX = enemyAI.transform.position.x - startPosition.x;
                if (false /*math.abs(relativeX) >= roamingRadius*/)
                {
                    // speed in entgegengesetzte richtung vom relativen x
                    //enemyAI.GetComponent<Rigidbody2D>().velocity = new Vector2(-math.sign(relativeX) * speed, 0);
                }
                else
                {
                    if (Random.value > 0.5f)
                    {
                        movementController.MoveRight();
                    }
                    else
                    {
                        movementController.MoveLeft();
                    }
                }
            }
        }
    }
}