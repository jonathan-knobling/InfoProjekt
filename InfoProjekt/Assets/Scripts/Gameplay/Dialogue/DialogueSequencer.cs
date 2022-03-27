using Gameplay.Dialogue.Nodes;
using Tech.Flow;
using UnityEngine;

namespace Gameplay.Dialogue
{
    public class DialogueSequencer
    {
        public delegate void DialogueCallback(Gameplay.Dialogue.Util.Dialogue dialogue);
        public delegate void DialogueNodeCallback(DialogueNode dialogueNode);

        public DialogueCallback OnStartDialogue;
        public DialogueCallback OnEndDialogue;
        public DialogueNodeCallback OnStartDialogueNode;
        public DialogueNodeCallback OnEndDialogueNode;
        
        private Gameplay.Dialogue.Util.Dialogue currentDialogue;
        private DialogueNode currentDialogueNode;

        private readonly FlowChannelSO flowChannel;

        public DialogueSequencer(FlowChannelSO flowChannel)
        {
            this.flowChannel = flowChannel;
        }

        public void StartDialogue(Gameplay.Dialogue.Util.Dialogue dialogue)
        {
            //wenn kein dialog aktiv ist
            if (currentDialogue == null && dialogue.startNode != null)
            {
                currentDialogue = dialogue;
                Debug.Log(dialogue.startNode.name);
                StartDialogueNode(dialogue.startNode);
                //event invoken dass ein dialog gestartet hat
                OnStartDialogue?.Invoke(dialogue);
                flowChannel.ChangeFlowState(FlowState.Dialogue);
            }
            else
            {
                Debug.Log("dialogue is null oder is schon n dialog am laufen");
            }
        }

        public void EndDialogue(Gameplay.Dialogue.Util.Dialogue dialogue)
        {
            if (currentDialogue == dialogue)
            {
                currentDialogueNode = null;
                currentDialogue = null;
                //event invoken dass der dialog geendet hat
                OnEndDialogue?.Invoke(dialogue);
                flowChannel.ChangeFlowState(FlowState.Default);
            }
        }

        public void StartDialogueNode(DialogueNode dialogueNode)
        {
            if (dialogueNode.Equals(currentDialogue.startNode) || currentDialogueNode.CanBeFollowedByNode(dialogueNode))
            {
                currentDialogueNode = dialogueNode;
                OnStartDialogueNode?.Invoke(dialogueNode);
            }
        }
    }
}