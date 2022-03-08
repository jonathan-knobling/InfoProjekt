using System.ComponentModel;
using NPCs.Dialogue.Events;
using NPCs.Dialogue.Util;
using UnityEngine;

namespace NPCs.Dialogue.Nodes
{
    public abstract class DialogueNode: ScriptableObject
    {
        [Description(description: "the text displayed on the button if this is the followup node to a choice node")]
        [SerializeField] public string choiceNodeButtonText;
        [SerializeField] public DialogueLine line;
        [SerializeField] public DialogueEvent dialogueEvent;

        public abstract bool CanBeFollowedByNode(DialogueNode node);
        public abstract void Visit(IDialogueNodeVisitor visitor);
    }
}