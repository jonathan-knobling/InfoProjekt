using System.Collections.Generic;
using UnityEngine;

namespace Quests
{
    public class QuestHandler : MonoBehaviour
    {
        [SerializeField] private List<Quest> quests;

        void Update()
        {
            quests.ForEach(quest =>
            {
                quest.Update();
                // nicht final
                if (quest.completed)
                {
                    quests.Remove(quest);
                }
            });
        }

        public void addQuest(Quest quest)
        {
            quests.Add(quest);
        }
    }
}
