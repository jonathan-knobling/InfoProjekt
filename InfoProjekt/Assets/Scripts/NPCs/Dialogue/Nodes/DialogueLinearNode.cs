using UnityEngine;

namespace NPCs.Dialogue.Nodes
{
    [CreateAssetMenu(menuName = "Dialogue/Nodes/Linear Node")]
    public class DialogueLinearNode: DialogueNode
    {
        [SerializeField] public DialogueNode nextNode;
        [SerializeField] public string nextButtonText = "OK";
        public override bool CanBeFollowedByNode(DialogueNode node)
        {
            return node == nextNode;
        }

        public override void Visit(IDialogueNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}