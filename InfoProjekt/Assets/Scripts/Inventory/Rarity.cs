using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = "Items/Rarity")]
    public class Rarity: ScriptableObject
    {
        [SerializeField] private Color color;
        [SerializeField] private string rarityName;
        
        //getter
        public Color Color => color;
        public string RarityName => rarityName;
    }
}