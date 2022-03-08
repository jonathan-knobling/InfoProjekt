using UnityEngine;

namespace NPCs.Dialogue.Util
{
    [CreateAssetMenu(menuName = "Dialogue/Line")]
    public class DialogueLine: ScriptableObject
    {
        [SerializeField] public DialogueCharacter speaker;
        [SerializeField] public string line;
    }
}