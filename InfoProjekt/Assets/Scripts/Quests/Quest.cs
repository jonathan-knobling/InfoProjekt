using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using UnityEngine;

namespace Quests
{
    [CreateAssetMenu(menuName = "Quests/Quest")]
    public class Quest: ScriptableObject
    {
        public QuestGoal[] goals;
        public string questName;
        public string description;
        public bool completed;

        public void Init()
        {
            for (int i = 0; i < goals.Length; i++)
            {
                goals[i].Init();
            }
        }
        
        public void Update()
        {
            // update all goals
            foreach (var goal in goals) goal.Update();
            // check if all goals are completed
            completed = goals.All(goal => goal.completed);
        }
    }
}
