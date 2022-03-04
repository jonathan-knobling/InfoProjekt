using Player;
using UnityEngine;
using Util;

namespace Quests
{
    [CreateAssetMenu(menuName = "Quests/Kill Goal")]
    public class QuestKillGoal: QuestGoal
    {
        public string enemyID;
        
        public QuestKillGoal(string description, int currentAmount, int requiredAmount, string enemyID) : base(description, currentAmount, requiredAmount)
        {
            this.enemyID = enemyID;
        }

        public override void Update()
        {
            PlayerCombatController.Instance.OnEnemyKilled += EnemyKilledListener;
            completed = currentAmount >= requiredAmount;
        }

        private void EnemyKilledListener(object sender, StringEventArgs e)
        {
            string enemyID = e.Data;
            if (this.enemyID == enemyID)
            {
                currentAmount++;
                Debug.Log("Enemy Killed");
            }
        }
    }
}