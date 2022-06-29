using Gameplay.Inventory;
using Gameplay.Inventory.Items;
using UnityEngine.UIElements;

namespace UI.Specific.PlayerUI
{
    public class HotbarUIController
    {
        private const string HotbarSlotClassName = "hotbar_slot";

        private readonly VisualElement[] hotbarSlotItems;

        public HotbarUIController(VisualElement root, InventoryManager inventory)
        {
            var hotbarSlots = new VisualElement[9];
            hotbarSlotItems = new VisualElement[9];

            inventory.OnInventoryChange += OnInventoryChange;
            
            for (int i = 0; i < 9; i++)
            {
                //create new hotbarslot visualelement add the hotbar_slot uss class and add it to the root
                var hotbarSlot = new VisualElement();
                hotbarSlot.AddToClassList(HotbarSlotClassName);
                root.Add(hotbarSlot);
                hotbarSlots[i] = hotbarSlot;
                
                //add a visualelement that contains the item sprite for the hotbar slot
                var hotbarSlotItem = new VisualElement();
                hotbarSlot.Add(hotbarSlotItem);
                hotbarSlotItems[i] = hotbarSlotItem;
                
                //add item sprite to hotbarslot
                hotbarSlotItem.style.backgroundImage = inventory.hotbarItems[i] == null
                    ? new StyleBackground() : new StyleBackground(inventory.hotbarItems[i].Sprite);
            }
        }

        private void OnInventoryChange(int changedIndex, Item item)
        {
            if (changedIndex < hotbarSlotItems.Length)
            {
                //wenn item null is background = kein image ansonsten image auf itemsprite updaten
                hotbarSlotItems[changedIndex].style.backgroundImage = item == null
                    ? new StyleBackground() : new StyleBackground(item.Sprite);
            }
        }
    }
}