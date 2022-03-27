using UnityEngine;

namespace Gameplay.Dialogue.Events
{
    public abstract class DialogueEvent: ScriptableObject
    {
        public abstract void Invoke();
    }
}