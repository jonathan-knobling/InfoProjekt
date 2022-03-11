using System;
using UnityEngine;

namespace Enemies.EnemyAI
{
    public class EnemyChasingState : EnemyState
    {
        private GameObject target;
        private float viewRadius;
        private EnemyMovementController movement;

        public override void EnterState(EnemyAI enemyAI)
        {
            target = enemyAI.target;
            viewRadius = enemyAI.viewRadius;
            movement = enemyAI.GetComponent<EnemyMovementController>();
        }

        public override void Update(EnemyAI enemyAI)
        {
            Vector2 pos = enemyAI.transform.position;
            Vector2 targetPos = target.transform.position;
            
            //wenn die distanz zwischen target und enemy kleiner 0.5 ist
            if (Math.Abs(targetPos.x - pos.x) < 0.5f)
            {
                movement.StopMoving();
                return;
            }// oder > viewradius nicht weiterbewegen 
            if (Math.Abs(targetPos.x - pos.x) > viewRadius)
            {
                movement.StopMoving();
                //und in roaming state switchen
                enemyAI.SwitchState();
                return;
            }
            if (targetPos.x < pos.x)
            {
                movement.MoveLeft();
            }
            else
            {
                movement.MoveRight();
            }
        }
    }
}
