using Gameplay.Dialogue.Nodes;
using UnityEngine;

namespace Gameplay.Dialogue.Util
{
    [CreateAssetMenu(menuName = "Dialogue/New Dialogue")]
    public class Dialogue: ScriptableObject
    {
        [SerializeField] public DialogueNode startNode;
    }
}