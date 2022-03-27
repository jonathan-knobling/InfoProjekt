using System.ComponentModel;
using Gameplay.Dialogue.Events;
using Gameplay.Dialogue.Util;
using UnityEngine;

namespace Gameplay.Dialogue.Nodes
{
    public abstract class DialogueNode: ScriptableObject
    {
        [Description("the text displayed on the button if this is the followup node to a choice node")]
        [SerializeField] public string choiceNodeButtonText;
        [SerializeField] public DialogueLine line;
        [SerializeField] public DialogueEvent dialogueEvent;

        public abstract bool CanBeFollowedByNode(DialogueNode node);
        public abstract void Visit(IDialogueNodeVisitor visitor);
    }
}