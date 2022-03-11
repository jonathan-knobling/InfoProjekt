using Quests;
using UnityEngine;

namespace NPCs.Dialogue.Events
{
    [CreateAssetMenu(menuName = "Dialogue/Events/Accept Quest")]
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