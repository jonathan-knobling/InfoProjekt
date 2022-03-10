using NPCs.Dialogue.Nodes;
using UnityEngine;

namespace NPCs.Dialogue.UI
{
    public class DialogueChoiceNodeUI
    {
        public DialogueChoiceNodeUI(DialogueSequencer sequencer, DialogueNode node)
        {
            this.sequencer = sequencer;
            this.node = node;
        }

        private DialogueSequencer sequencer;
        private DialogueNode node;

        public void OnButtonClicked()
        {
            Debug.Log("button clicked");
            sequencer.StartDialogueNode(node);
        } 
    }
}