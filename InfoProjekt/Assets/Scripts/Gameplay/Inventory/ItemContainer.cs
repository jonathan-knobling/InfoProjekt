using Gameplay.Inventory.Items;
using Inventory.Items;

namespace Gameplay.Inventory
{
    public interface IItemContainer
    {
        void AddItem(Item item);
        void AddItem(StackableItem item);
        void AddItem(NonStackableItem item);

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