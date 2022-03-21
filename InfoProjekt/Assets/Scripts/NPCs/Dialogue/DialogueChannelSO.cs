using System;
using UnityEngine;
using Util.EventArgs;

namespace NPCs.Dialogue
{
    [CreateAssetMenu(menuName = "Channels/Dialogue Channel")]
    public class DialogueChannelSO: ScriptableObject
    {
        public event EventHandler<DialogueEventArgs> OnRequestDialogue;
        
        public void RequestDialog(Util.Dialogue dialogue)
        {
            OnRequestDialogue?.Invoke(this, new DialogueEventArgs(dialogue));
        }
    }
}