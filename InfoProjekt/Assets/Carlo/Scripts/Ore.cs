
using Inventory.Items;
using UnityEngine;

namespace Assets.Carlo.Scripts
{
    [CreateAssetMenu(fileName = "New Ore", menuName = "Items/Ore")]
    public class Ore : StackableItem
    {
        [SerializeField] private string type;
    }
}