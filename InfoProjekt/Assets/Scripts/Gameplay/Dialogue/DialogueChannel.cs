using System;
using Util.EventArgs;

namespace Gameplay.Dialogue
{
    public class DialogueChannel
    {
        public event EventHandler<DialogueEventArgs> OnRequestDialogue;
        
        public void RequestDialog(Gameplay.Dialogue.Util.Dialogue dialogue)
        {
            OnRequestDialogue?.Invoke(this, new DialogueEventArgs(dialogue));
        }
    }
}