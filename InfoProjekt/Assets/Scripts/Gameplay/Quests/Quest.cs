using System.Linq;
using Environment.Actors.Player;
using UnityEngine;

namespace Gameplay.Quests
{
    [CreateAssetMenu(menuName = "Quests/Quest")]
    public class Quest: ScriptableObject
    {
        public QuestGoal[] goals;
        //public Quest[] subQuests;
        public string questName;
        public string description;
        public bool completed;

        public void Init(PlayerCombatChannelSO combatChannel)
        {
            for (int i = 0; i < goals.Length; i++)
            {
                //initialize all goals
                goals[i].Init(combatChannel);
            }
        }
        
        public void Update()
        {
            // update all goals
            foreach (var goal in goals) goal.Update();
            // check if all goals are completed
            completed = goals.All(goal => goal.completed);

            /*if (subQuests != null)
            {
                //update all subquests
                foreach (var quest in subQuests) quest.Update();
            }*/
        }
    }
}
