using UnityEngine;

namespace Inventory
{
    public class Rarity: ScriptableObject
    {
        [SerializeField] private Color color;
        [SerializeField] private string rarityName;
        
        //getter
        public Color Color => color;
        public string RarityName => rarityName;
    }
}