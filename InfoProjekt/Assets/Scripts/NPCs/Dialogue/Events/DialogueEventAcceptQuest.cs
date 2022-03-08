using Quests;
using UnityEngine;

namespace NPCs.Dialogue.Events
{
    public class DialogueEventAcceptQuest: DialogueEvent
    {
        [SerializeField] public string eventName;
        [SerializeField] public Quest quest;
        
        public override void Invoke()
        {
            QuestHandler.Instance.addQuest(quest);
        }
    }
}