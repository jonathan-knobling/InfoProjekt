using NPCs.Dialogue.Nodes;
using UnityEngine;

namespace NPCs.Dialogue
{
    public interface IDialogueNodeVisitor
    {
        void Visit(DialogueLinearNode linearNode);
        abstract void Visit(DialogeChoiceNode choiceNode);
    }
}