using Gameplay.Dialogue.Util;

namespace Util.EventArgs
{
    public class DialogueEventArgs: System.EventArgs
    {
        public Dialogue Dialogue { get; }

        public DialogueEventArgs(Dialogue dialogue)
        {
            Dialogue = dialogue;
        }
    }
}