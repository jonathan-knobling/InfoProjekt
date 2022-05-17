﻿using UnityEngine;
using Util.FSM;

namespace Actors.Enemies.EnemyAI
{
    public class EnemyRoamingState: State
    {
        private readonly GameObject enemy;

        public EnemyRoamingState(GameObject enemy)
        {
            this.enemy = enemy;
        }

        public override void OnStateEnter()
        {
            enemy.GetComponent<SpriteRenderer>().color = Color.green;
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