using Actors.Player;
using Tech;
using UnityEngine;

namespace Gameplay.Quests
{
    public abstract class QuestGoal : ScriptableObject
    {
        public string description;
        public bool completed;
        public int currentAmount;
        public int requiredAmount;

        public abstract void Init(EventChannelSO eventChannel);

        protected QuestGoal()
        {
            currentAmount = 0;
            completed = false;
        }
        
        public abstract void Update();
    }
}