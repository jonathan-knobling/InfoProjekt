using System.ComponentModel;
using Gameplay.Inventory.Items;

namespace Gameplay.Inventory
{
    public interface IItemContainer
    {
        [Description("Returns the first empty slot or -1 if no slot is empty")]
        int GetFirstEmptySlot();
        bool DropSlot(int slot);
        void RemoveSlot(int slot);
        Item GetSlot(int slot);

        bool TryAddItem(Item item);
        bool TryAddItem(StackableItem item);
        bool TryAddItem(NonStackableItem item);
        
        bool TryAddItem(Item item, int slot);
        bool TryAddItem(StackableItem item, int slot);
        bool TryAddItem(NonStackableItem item, int slot);

        bool HasItem(NonStackableItem item);
        bool HasItem(string name);
        bool HasItem(StackableItem item, float amount);
        
        bool RemoveItem(StackableItem item, float amount);
        bool RemoveItem(NonStackableItem item);
        
        void DropItem(Item item);
        void DropItem(StackableItem item, float amount);
        void DropItem(NonStackableItem item);
    }
}