using Gameplay.Quests;
using Tech;
using UnityEngine;

namespace Gameplay.Dialogue.Events
{
    [CreateAssetMenu(menuName = "Dialogue/Events/Accept Quest")]
    public class DialogueEventAcceptQuest: DialogueEvent
    {
        [SerializeField] private EventChannelSO eventChannel;
        [SerializeField] public string eventName;
        [SerializeField] private Quest quest;
        
        public override void Invoke()
        {
            eventChannel.QuestChannel.RequestAddQuest(quest);
        }
    }
}