using System;
using Player;
using UnityEngine;

namespace Enemies.EnemyAI
{
    public class EnemyChasingState : EnemyState
    {
        private float viewRadius;
        private EnemyMovementController movement;
        private static readonly int Hit = Animator.StringToHash("hit"); // cached property

        public override void EnterState(EnemyAI enemyAI)
        {
            
            viewRadius = enemyAI.ViewRadius;
            movement = enemyAI.GetComponent<EnemyMovementController>();
        }

        public override void Update(EnemyAI enemyAI)
        {
            GameObject target = enemyAI.Target;
            if (target == null)
            {
                return;
            }
            float posX = enemyAI.transform.position.x;
            float targetPosX = target.transform.position.x;
            
            //wenn der abstand kleiner is als hitradius
            if (Math.Abs(targetPosX - posX) < enemyAI.HitRadius)
            {
                target.GetComponent<Stats>().DealDamage(enemyAI.Stats.AttackDamage);
                enemyAI.Animator.SetTrigger(Hit);
            }
            
            //wenn die distanz zwischen target und enemy kleiner mindestabstand ist
            if (Math.Abs(targetPosX - posX) < enemyAI.MinTargetDistance)
            {
                movement.StopMoving();
                return;
            }// oder > viewradius nicht weiterbewegen 
            if (Math.Abs(targetPosX - posX) > viewRadius)
            {
                movement.StopMoving();
                //und in roaming state switchen
                enemyAI.SwitchState();
                return;
            }
            if (targetPosX < posX)
            {
                movement.MoveLeft(enemyAI.Stats.Speed);
            }
            else
            {
                movement.MoveRight(enemyAI.Stats.Speed);
            }
        }
    }
}
