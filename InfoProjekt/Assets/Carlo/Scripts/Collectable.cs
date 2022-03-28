
using UnityEngine;


namespace Inventory.Items
{
    [CreateAssetMenu(fileName = "New Collectable", menuName = "Items/Collectables")]
    public class Collectable : StackableItem
    {
        [SerializeField] private string type;
        [SerializeField] public Sprite image;
    }
}