using UnityEngine;
using Util.FSM;

namespace Actors.Enemies.EnemyAI
{
    public class EnemyAttackingState: State
    {
        private GameObject enemy;

        public EnemyAttackingState(GameObject enemy)
        {
            this.enemy = enemy;
        }
        
        public override void OnStateEnter()
        {
            enemy.GetComponent<SpriteRenderer>().color = Color.red;
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