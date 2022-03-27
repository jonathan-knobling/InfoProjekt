using Gameplay.Quests;
using UnityEngine;

namespace Gameplay.Dialogue.Events
{
    [CreateAssetMenu(menuName = "Dialogue/Events/Accept Quest")]
    public class DialogueEventAcceptQuest: DialogueEvent
    {
        [SerializeField] private QuestChannelSO questChannel;
        [SerializeField] public string eventName;
        [SerializeField] private Quest quest;
        
        public override void Invoke()
        {
            questChannel.RequestAddQuest(quest);
        }
    }
}