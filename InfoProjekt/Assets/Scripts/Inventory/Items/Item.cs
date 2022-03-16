using UnityEngine;

namespace Inventory.Items
{
    public abstract class Item: ScriptableObject
    {
        [SerializeField] private new string name;
        [SerializeField] private Sprite sprite;
        [SerializeField] private Rarity rarity;
        [SerializeField] private int amount;

        //getter
        public virtual Sprite Sprite => sprite;
        public virtual string Name => name;
        public virtual Rarity Rarity => rarity;
        public virtual int Amount => amount;

        public virtual void AddItemAmount(int itemAmount)
        {
            amount += itemAmount;
        }

        public virtual void RemoveItemAmount(int removeAmount)
        {
            amount -= removeAmount;
        }
    }
}