using System;
using Gameplay.Dialogue.Nodes;
using Tech.Flow;
using UnityEngine;

namespace Gameplay.Dialogue
{
    public class DialogueSequencer
    {
        public Action<Util.Dialogue> OnStartDialogue;
        public Action<Util.Dialogue> OnEndDialogue;
        public Action<DialogueNode> OnStartDialogueNode;
        
        private Util.Dialogue currentDialogue;
        private DialogueNode currentDialogueNode;

        private readonly FlowChannel flowChannel;

        public DialogueSequencer(FlowChannel flowChannel)
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
            if (dialogueNode is null)
            {
                EndDialogue(currentDialogue);
                return;
            }
            
            if (!dialogueNode.Equals(currentDialogue.startNode) && !currentDialogueNode.CanBeFollowedByNode(dialogueNode)) return;
            
            currentDialogueNode = dialogueNode;
            OnStartDialogueNode?.Invoke(dialogueNode);
        }
    }
}