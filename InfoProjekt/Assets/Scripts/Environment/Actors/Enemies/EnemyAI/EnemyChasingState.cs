using System;
using Environment.Actors.Player;
using Environment.Actors.Player.Stats;
using UnityEngine;

namespace Environment.Actors.Enemies.EnemyAI
{
    public class EnemyChasingState : EnemyState
    {
        private float viewRadius;
        private EnemyMovementController movement;
        private static readonly int CPAttack = Animator.StringToHash("attack");

        public EnemyChasingState()
        {
            Name = "chasingstate";
        }
        
        public override void EnterState(Environment.Actors.Enemies.EnemyAI.EnemyAI enemyAI)
        {
            viewRadius = enemyAI.ViewRadius;
            movement = enemyAI.GetComponent<EnemyMovementController>();
        }

        public override void Update(Environment.Actors.Enemies.EnemyAI.EnemyAI enemyAI)
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
                target.GetComponent<PlayerStats>().DealDamage(enemyAI.Stats.AttackDamage);
                enemyAI.Animator.SetTrigger(CPAttack);
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
