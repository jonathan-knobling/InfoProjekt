using UnityEngine;

namespace Quests
{
    public abstract class QuestGoal : ScriptableObject
    {
        public string description;
        public bool completed;
        public int currentAmount;
        public int requiredAmount;

        public abstract void Init();

        public QuestGoal()
        {
            currentAmount = 0;
            completed = false;
        }
        
        public abstract void Update();
    }
}