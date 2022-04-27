using Actors.Player;
using Environment.ObjectRegister;
using Gameplay.Dialogue;
using Gameplay.Quests;
using Tech.Audio;
using Tech.Flow;
using Tech.IO.PlayerInput;
using Tech.IO.Saves;
using UI.Generic;
using UnityEngine;

namespace Tech
{
    [CreateAssetMenu(menuName = "Event Channel")]
    public class EventChannelSO: ScriptableObject
    {
        public readonly UIChannel UIChannel;
        public readonly IOChannel IOChannel;
        public readonly InputChannel InputChannel;
        public readonly AudioRequestChannel AudioRequestChannel;
        public readonly QuestChannel QuestChannel;
        public readonly DialogueChannel DialogueChannel;
        public readonly ObjectRegisterChannel ObjectRegisterChannel;
        public readonly PlayerChannel PlayerChannel;
        public readonly FlowChannel FlowChannel;

        public EventChannelSO()
        {
            UIChannel = new UIChannel();
            IOChannel = new IOChannel();
            InputChannel = new InputChannel();
            AudioRequestChannel = new AudioRequestChannel();
            QuestChannel = new QuestChannel();
            DialogueChannel = new DialogueChannel();
            ObjectRegisterChannel = new ObjectRegisterChannel();
            PlayerChannel = new PlayerChannel();
            FlowChannel = new FlowChannel(PlayerChannel, InputChannel);
        }
    }
}