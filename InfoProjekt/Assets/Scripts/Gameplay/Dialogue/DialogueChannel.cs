using System;
using Util.EventArgs;

namespace Gameplay.Dialogue
{
    public class DialogueChannel
    {
        public event Action<DialogueEventArgs> OnRequestDialogue;

        public void RequestDialog(Gameplay.Dialogue.Util.Dialogue dialogue)
        {
            OnRequestDialogue?.Invoke(new DialogueEventArgs(dialogue));
        }
    }
}