using Gameplay.Dialogue.Nodes;
using UnityEngine;

namespace Gameplay.Dialogue.UI
{
    public class DialogueNodeButton
    {
        private readonly DialogueNode node;

        private readonly DialogueSequencer sequencer;

        public DialogueNodeButton(DialogueSequencer sequencer, DialogueNode node)
        {
            this.sequencer = sequencer;
            this.node = node;
        }

        public void OnButtonClicked()
        {
            Debug.Log("button clicked");
            sequencer.StartDialogueNode(node);
        }
    }
}