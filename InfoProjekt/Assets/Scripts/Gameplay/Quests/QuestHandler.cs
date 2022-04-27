using System.Collections.Generic;
using Actors.Player;
using Tech;
using UnityEngine;

namespace Gameplay.Quests
{
    public class QuestHandler : MonoBehaviour
    {
        [SerializeField] private EventChannelSO eventChannel;
        [SerializeField] private List<Quest> quests;

        private void Start()
        {
            quests.ForEach(quest => quest.Init(eventChannel));
            eventChannel.QuestChannel.OnRequestAddQuest += AddQuest;
        }

        private void Update()
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

        private void AddQuest(Quest quest)
        {
            quests.Add(quest);
        }
    }
}
