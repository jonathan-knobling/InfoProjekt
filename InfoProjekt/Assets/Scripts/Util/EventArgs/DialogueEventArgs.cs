using NPCs.Dialogue.Util;

namespace Util.EventArgs
{
    public class DialogueEventArgs: System.EventArgs
    {
        public Dialogue dialogue { get; private set; }

        public DialogueEventArgs(Dialogue dialogue)
        {
            this.dialogue = dialogue;
        }
    }
}