using NPCs.Dialogue.Nodes;
using UnityEngine;

namespace NPCs.Dialogue.UI
{
    public class DialogueChoiceNodeUI
    {
        private readonly DialogueNode node;

        private readonly DialogueSequencer sequencer;

        public DialogueChoiceNodeUI(DialogueSequencer sequencer, DialogueNode node)
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