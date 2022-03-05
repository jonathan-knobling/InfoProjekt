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

        protected QuestGoal(string description, int currentAmount, int requiredAmount)
        {
            this.description = description;
            this.currentAmount = currentAmount;
            this.requiredAmount = requiredAmount;
            completed = false;
        }

        public abstract void Update();
    }
}