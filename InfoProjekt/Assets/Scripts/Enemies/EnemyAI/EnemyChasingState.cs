using System;
using Player;
using UnityEngine;

namespace Enemies.EnemyAI
{
    public class EnemyChasingState : EnemyState
    {
        private float viewRadius;
        private EnemyMovementController movement;
        private static readonly int CPAttack = Animator.StringToHash("attack");

        public EnemyChasingState()
        {
            name = "chasingstate";
        }
        
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
                Debug.Log("abstand kleiner als hitradius");
                target.GetComponent<Stats>().DealDamage(enemyAI.Stats.AttackDamage);
                enemyAI.Animator.SetTrigger(CPAttack);
            }
            
            //wenn die distanz zwischen target und enemy kleiner mindestabstand ist
            if (Math.Abs(targetPosX - posX) < enemyAI.MinTargetDistance)
            {
                Debug.Log("distanz kleiner als mindestabstand");
                movement.StopMoving();
                return;
            }// oder > viewradius nicht weiterbewegen 
            if (Math.Abs(targetPosX - posX) > viewRadius)
            {
                Debug.Log("distanz größer als viewradius");
                movement.StopMoving();
                //und in roaming state switchen
                enemyAI.SwitchState();
                return;
            }
            if (targetPosX < posX)
            {
                Debug.Log("move left");
                movement.MoveLeft(enemyAI.Stats.Speed);
            }
            else
            {
                Debug.Log("move right");
                movement.MoveRight(enemyAI.Stats.Speed);
            }
        }
    }
}
