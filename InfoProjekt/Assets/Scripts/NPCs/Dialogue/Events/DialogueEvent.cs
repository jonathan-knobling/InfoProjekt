using UnityEngine;

namespace NPCs.Dialogue.Events
{
    public abstract class DialogueEvent: ScriptableObject
    {
        public abstract void Invoke();
    }
}