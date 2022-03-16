using UnityEngine;

namespace Inventory.Items
{
    [CreateAssetMenu(menuName = "Items/Weapon")]
    public class WeaponItem: Item
    {
        [SerializeField] private float attackMultiplier = 1f;
        [SerializeField] private float attackCooldown = 1f;
        
        //getter
        public float AttackMultiplier => attackMultiplier;
        public float AttackCooldown => attackCooldown;
    }
}