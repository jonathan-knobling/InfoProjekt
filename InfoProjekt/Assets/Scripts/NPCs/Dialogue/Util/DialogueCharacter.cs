using UnityEngine;

namespace NPCs.Dialogue.Util
{
     [CreateAssetMenu(menuName = "Dialogue/Character")]
    public class DialogueCharacter: ScriptableObject
    {
        [SerializeField] public string characterName;
    }
}