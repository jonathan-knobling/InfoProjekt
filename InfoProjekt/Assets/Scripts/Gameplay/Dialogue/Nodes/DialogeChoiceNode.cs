using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Dialogue.Nodes
{
    [CreateAssetMenu(menuName = "Dialogue/Nodes/Choice Node")]
    public class DialogeChoiceNode: DialogueNode
    {
        [SerializeField] public List<DialogueNode> choices;
        public override bool CanBeFollowedByNode(DialogueNode node)
        {
            if (choices.Contains(node))
            {
                return true;
            }
            return false;
        }

        public override void Visit(IDialogueNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}