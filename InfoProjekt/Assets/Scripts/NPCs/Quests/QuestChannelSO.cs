using System;
using UnityEngine;

namespace NPCs.Quests
{
    [CreateAssetMenu(menuName = "Channels/Quest Channel")]
    public class QuestChannelSO: ScriptableObject
    {
        public Action<Quest> OnRequestAddQuest;

        public void RequestAddQuest(Quest quest)
        {
            OnRequestAddQuest?.Invoke(quest);
        }
    }
}