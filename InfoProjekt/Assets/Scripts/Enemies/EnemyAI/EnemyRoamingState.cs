using UnityEngine;
using Util;

namespace Enemies.EnemyAI
{
    public class EnemyRoamingState : EnemyState
    {

        private EnemyMovementController movementController;
        private Vector2 startPosition;
        private Timer actionTimer;

        public EnemyRoamingState()
        {
            // idle time after spawn
            actionTimer = new Timer(1.5f);
        }
    
        public override void EnterState(EnemyAI enemyAI)
        {
            startPosition = enemyAI.StartingPosition;
            movementController = enemyAI.GetComponent<EnemyMovementController>();
        }

        public override void Update(EnemyAI enemyAI)
        {
            //change enemy actions with random timer
            if (actionTimer == null || actionTimer.Elapsed)
            {
                actionTimer = new Timer(Random.Range(1.5f, 0.3f));
                PerformRandomMovement(enemyAI);
            }
            actionTimer.Update();
            
            Collider2D collider = enemyAI.CheckView();
            if (collider != null)
            {
                enemyAI.SwitchState();
                enemyAI.Target = collider.GetComponent<GameObject>();
            }
        }

        private void PerformRandomMovement(EnemyAI enemyAI)
        {
            if (Random.value > 0.5f) //idle action
            {
                enemyAI.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            else
            {
                /*float roamingRadius = enemyAI.RoamingRadius;
                float relativeX = enemyAI.transform.position.x - startPosition.x;
                if (math.abs(relativeX) >= roamingRadius)
                {
                    //speed in entgegengesetzte richtung vom relativen x
                    enemyAI.GetComponent<Rigidbody2D>().velocity = new Vector2(-math.sign(relativeX) * speed, 0);
                }
                else*/
                {
                    if (Random.value > 0.5f)
                    {
                        movementController.MoveRight(enemyAI.Stats.RoamingSpeed);
                    }
                    else
                    {
                        movementController.MoveLeft(enemyAI.Stats.RoamingSpeed);
                    }
                }
            }
        }
    }
}