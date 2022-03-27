
using UnityEngine;


namespace Inventory.Items
{
    [CreateAssetMenu(fileName = "New Ore", menuName = "Items/Ore")]
    public class Ore : StackableItem
    {
        [SerializeField] private string type;
        [SerializeField] public Sprite image;
    }
}