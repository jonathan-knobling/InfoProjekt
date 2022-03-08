using NPCs.Dialogue.Nodes;
using UnityEngine;

namespace NPCs.Dialogue.Util
{
    [CreateAssetMenu(menuName = "Dialogue/New Dialogue")]
    public class Dialogue: ScriptableObject
    {
        [SerializeField] public DialogueNode startNode;
    }
}