using Unity.Mathematics;
using UnityEngine;
using Util;
using Random = UnityEngine.Random;

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
                //neue timer der sagt wie lange die bewegung dauert
                actionTimer = new Timer(Random.Range(5f, 0.6f));
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
                float roamingRadius = enemyAI.RoamingRadius;
                float relativeX = enemyAI.transform.position.x - startPosition.x;
                if (math.abs(relativeX) >= roamingRadius)
                {
                    //moven in entgegengesetzte richtung vom relativen x
                    movementController.MoveRight(-math.sign(relativeX));
                }
                else
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