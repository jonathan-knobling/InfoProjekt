using System;
using UnityEngine;
using Util.EventArgs;

namespace NPCs.Dialogue
{
    [CreateAssetMenu(menuName = "Dialogue/Dialogue Channel")]
    public class DialogueChannelSO: ScriptableObject
    {
        public event EventHandler<DialogueEventArgs> OnRequestDialogue;
        
        public void RequestDialog(Util.Dialogue dialogue)
        {
            OnRequestDialogue?.Invoke(this, new DialogueEventArgs(dialogue));
        }
        
        [SerializeField] private Util.Dialogue test;
        public void Test(object sender, EventArgs eventArgs)
        {
            if (test == null)
            {
                Debug.Log("Dialogue Test == null");
                return;
            }
            OnRequestDialogue?.Invoke(this, new DialogueEventArgs(test));
        }
    }
}