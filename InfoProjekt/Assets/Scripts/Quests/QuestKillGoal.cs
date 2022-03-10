using Player;
using UnityEngine;
using Util;
using Util.EventArgs;

namespace Quests
{
    [CreateAssetMenu(menuName = "Quests/Kill Goal")]
    public class QuestKillGoal: QuestGoal
    {
        public string enemyID;

        public override void Init()
        {
            PlayerCombatController.Instance.OnEnemyKilled += EnemyKilledListener;
        }

        public override void Update()
        {
            completed = currentAmount >= requiredAmount;
        }

        private void EnemyKilledListener(object sender, StringEventArgs e)
        {
            string enemyID = e.data;
            if (this.enemyID == enemyID)
            {
                currentAmount++;
                Debug.Log(currentAmount);
            }
        }
    }
}