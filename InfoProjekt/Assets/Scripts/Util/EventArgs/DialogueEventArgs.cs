using NPCs.Dialogue.Util;

namespace Util.EventArgs
{
    public class DialogueEventArgs: System.EventArgs
    {
        public Dialogue Dialogue { get; private set; }

        public DialogueEventArgs(Dialogue dialogue)
        {
            Dialogue = dialogue;
        }
    }
}