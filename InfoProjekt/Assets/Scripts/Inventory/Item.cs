using UnityEngine;

namespace Inventory
{
    public abstract class Item: ScriptableObject
    {
        [SerializeField] private new string name;
        [SerializeField] private Sprite sprite;
        [SerializeField] private Rarity rarity;

        //getter
        public Sprite Sprite => sprite;
        public string Name => name;
        public Rarity Rarity => rarity;
    }
}