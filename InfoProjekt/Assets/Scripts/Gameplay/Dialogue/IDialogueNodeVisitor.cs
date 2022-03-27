using Gameplay.Dialogue.Nodes;

namespace Gameplay.Dialogue
{
    public interface IDialogueNodeVisitor
    {
        void Visit(DialogueLinearNode linearNode);
        abstract void Visit(DialogeChoiceNode choiceNode);
    }
}