using System;
using Actors.Player;
using Tech.Flow.States;
using Tech.IO;
using Tech.IO.PlayerInput;
using UnityEngine;

namespace Tech.Flow
{
    [CreateAssetMenu(menuName = "Channels/Flow Channel")]
    public class FlowChannelSO: ScriptableObject
    {
        [SerializeField] private PlayerCombatChannelSO combatChannel;
        [SerializeField] private PlayerMovementChannelSO movementChannel;
        [SerializeField] private InputChannelSO inputChannel;

        private readonly FlowStateDefault defaultState;
        private readonly FlowStatePaused pausedState;
        private FlowStateDialogue dialogueState;

        public event Action<IFlowState> OnChangeFlowState;

        public FlowChannelSO()
        {
            defaultState = new FlowStateDefault();
            pausedState = new FlowStatePaused();
        }

        public void ChangeFlowState(FlowState state)
        {
            switch (state)
            {
                case FlowState.Default:
                {
                    OnChangeFlowState?.Invoke(defaultState);
                    break;
                }
                case FlowState.Paused:
                {
                    OnChangeFlowState?.Invoke(pausedState);
                    break;
                }
                case FlowState.Dialogue:
                {
                    dialogueState ??= new FlowStateDialogue(combatChannel, movementChannel, inputChannel);
                    OnChangeFlowState?.Invoke(dialogueState);
                    break;
                }
            }
        }
    }
}