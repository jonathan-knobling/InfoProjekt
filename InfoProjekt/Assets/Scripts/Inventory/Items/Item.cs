using UnityEngine;

namespace Inventory.Items
{
    public abstract class Item: ScriptableObject
    {
        [SerializeField] private new string name;
        [SerializeField] private Sprite sprite;
        [SerializeField] private Rarity rarity;
        //todo drop item wieder hinzuf�gen aber do

        //getter
        public Sprite Sprite => sprite;
        public string Name => name;
        public Rarity Rarity => rarity;

        public abstract void RequestAddItem(IItemContainer container);
        public abstract void RequestDropItem(IItemContainer container);
    }
}