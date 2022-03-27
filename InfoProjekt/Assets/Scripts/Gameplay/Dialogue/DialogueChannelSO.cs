using System;
using UnityEngine;
using Util.EventArgs;

namespace Gameplay.Dialogue
{
    [CreateAssetMenu(menuName = "Channels/Dialogue Channel")]
    public class DialogueChannelSO: ScriptableObject
    {
        public event EventHandler<DialogueEventArgs> OnRequestDialogue;
        
        public void RequestDialog(Gameplay.Dialogue.Util.Dialogue dialogue)
        {
            OnRequestDialogue?.Invoke(this, new DialogueEventArgs(dialogue));
        }
    }
}