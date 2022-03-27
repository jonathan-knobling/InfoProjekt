using Gameplay.Dialogue.Nodes;

namespace Gameplay.Dialogue
{
    public interface IDialogueNodeVisitor
    {
        void Visit(DialogueLinearNode linearNode);
        void Visit(DialogeChoiceNode choiceNode);
    }
}