using UnityEngine;

namespace Inventory.Items
{
    [CreateAssetMenu(menuName = "Items/Item")]
    public abstract class Item: ScriptableObject
    {
        [SerializeField] private new string name;
        [SerializeField] private Sprite sprite;
        [SerializeField] private Rarity rarity;

        //getter
        public virtual Sprite Sprite => sprite;
        public virtual string Name => name;
        public virtual Rarity Rarity => rarity;
    }
}