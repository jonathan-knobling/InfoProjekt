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
            name = "roamingstate";
            // idle time after spawn
            actionTimer = new Timer(1f);
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
                actionTimer = new Timer(Random.Range(1.8f, 0.5f));
                PerformRandomMovement(enemyAI);
            }
            actionTimer.Update();
            
            Collider2D collider = enemyAI.CheckView();
            if (collider != null)
            {
                enemyAI.Target = collider.gameObject;
                enemyAI.SwitchState();
            }
        }

        private void PerformRandomMovement(EnemyAI enemyAI)
        {
            if (Random.value > 0.5f) //idle action
            {
                movementController.StopMoving();
            }
            else
            {
                float roamingRadius = enemyAI.RoamingRadius;
                float relativeX = enemyAI.transform.position.x - startPosition.x;
                if (math.abs(relativeX) >= roamingRadius)
                {
                    //moven in entgegengesetzte richtung vom relativen x
                    movementController.Move(-math.sign(relativeX));
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