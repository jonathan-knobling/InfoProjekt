using System;
using JetBrains.Annotations;
using NPCs.Dialogue.Nodes;
using UnityEngine;

namespace NPCs.Dialogue
{
    public class DialogueSequencer
    {
        public delegate void DialogueCallback(Util.Dialogue dialogue);
        public delegate void DialogueNodeCallback(DialogueNode dialogueNode);

        public DialogueCallback OnStartDialogue;
        public DialogueCallback OnEndDialogue;
        public DialogueNodeCallback OnStartDialogueNode;
        public DialogueNodeCallback OnEndDialogueNode;
        
        private Util.Dialogue currentDialogue;
        private DialogueNode currentDialogueNode;

        public void StartDialogue(Util.Dialogue dialogue)
        {
            //wenn kein dialog aktiv ist
            if (currentDialogue == null && dialogue.startNode != null)
            {
                currentDialogue = dialogue;
                Debug.Log(dialogue.startNode.name);
                StartDialogueNode(dialogue.startNode);
                //event invoken dass ein dialog gestartet hat
                OnStartDialogue?.Invoke(dialogue);
            }
            else
            {
                throw new ArgumentNullException("dialogue.startNode", "Parameter Null or there is already a Dialogue active");
            }
        }

        public void EndDialogue(Util.Dialogue dialogue)
        {
            if (currentDialogue == dialogue)
            {
                currentDialogueNode = null;
                currentDialogue = null;
                //event invoken dass der dialog geendet hat
                OnEndDialogue?.Invoke(dialogue);
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