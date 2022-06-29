using System;

namespace Gameplay.Quests
{
    public class QuestChannel
    {
        public Action<Quest> OnRequestAddQuest;

        public void RequestAddQuest(Quest quest)
        {
            OnRequestAddQuest?.Invoke(quest);
        }
    }
}