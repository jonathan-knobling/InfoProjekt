using UnityEngine;

namespace Gameplay.Inventory.Items
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

        public abstract bool RequestAddItem(IItemContainer container, int slot);
        public abstract bool RequestAddItem(IItemContainer container);
        public abstract void RequestDropItem(IItemContainer container);
    }
}