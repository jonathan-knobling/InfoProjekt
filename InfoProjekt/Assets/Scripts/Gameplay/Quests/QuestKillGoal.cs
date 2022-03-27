using Environment.Actors.Player;
using UnityEngine;

namespace Gameplay.Quests
{
    [CreateAssetMenu(menuName = "Quests/Kill Goal")]
    public class QuestKillGoal: QuestGoal
    {
        public string enemyID;

        public override void Init(PlayerCombatChannelSO combatChannel)
        {
            combatChannel.OnEnemyKilled += EnemyKilledListener;
        }

        public override void Update()
        {
            completed = currentAmount >= requiredAmount;
        }

        private void EnemyKilledListener(string killedEnemyID)
        {
            if (enemyID == killedEnemyID)
            {
                currentAmount++;
                Debug.Log(currentAmount);
            }
        }
    }
}