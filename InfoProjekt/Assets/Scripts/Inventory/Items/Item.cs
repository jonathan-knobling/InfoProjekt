using UnityEngine;

namespace Inventory.Items
{
    public abstract class Item: ScriptableObject
    {
        [SerializeField] private new string name;
        [SerializeField] private Sprite sprite;
        [SerializeField] private Rarity rarity;
        [SerializeField] private GameObject dropItem;

        //getter
        public Sprite Sprite => sprite;
        public string Name => name;
        public Rarity Rarity => rarity;
        public GameObject DropItem => dropItem;

        public Item()
        {
            dropItem.GetComponent<Collectable>().item = this;
        }

        public abstract void RequestAddItem(IItemContainer container);
        public abstract void RequestDropItem(IItemContainer container);
    }
}