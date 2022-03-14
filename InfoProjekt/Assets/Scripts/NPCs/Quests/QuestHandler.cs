using System.Collections.Generic;
using UnityEngine;

namespace NPCs.Quests
{
    public class QuestHandler : MonoBehaviour
    {
        public static QuestHandler Instance;
        
        [SerializeField] private List<Quest> quests;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            quests.ForEach(quest => quest.Init());
        }

        void Update()
        {
            if (quests == null) return;
            
            quests.ForEach(quest => quest.Update());
            List<Quest> remove = new List<Quest>();
            quests.ForEach(quest =>
            {
                if (quest.completed)
                {
                    remove.Add(quest);
                }
            });
            if (remove.Count > 0)
            {
                remove.ForEach(quest => quests.Remove(quest));
            }
        }

        public void addQuest(Quest quest)
        {
            quests.Add(quest);
        }
    }
}
