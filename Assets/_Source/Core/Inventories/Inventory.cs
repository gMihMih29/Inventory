using System.Collections.Generic;
using _Source.Core.Items;

namespace _Source.Core.Inventories
{
    /// <summary>
    /// Represents player inventory.
    /// </summary>
    public class Inventory
    {
        private int _countFields;
        public List<Item> _items;
        public event System.Action<int> OnItemStored;
        public event System.Action<int, int> OnItemsSwapped;

        public Inventory(int countFields)
        {
            _countFields = countFields > 16 ? 16 : countFields;
            _items = new List<Item>();
            for (int i = 0; i < countFields; ++i)
            {
                _items.Add(new PermanentItem(ItemsEnum.Empty));
            }
        }
        
        /// <summary>
        /// Swap items in inventory.
        /// </summary>
        /// <param name="index">First item.</param>
        /// <param name="otherIndex">Second item.</param>
        public void SwapItems(int index, int otherIndex)
        {
            (_items[index], _items[otherIndex]) = (_items[otherIndex], _items[index]);
            OnItemsSwapped?.Invoke(index, otherIndex);
        }

        /// <summary>
        /// Add new item to inventory.
        /// Replaces first empty item with new item.
        /// </summary>
        /// <param name="item">New item.</param>
        public void AddNewItem(Item item)
        {
            for (int i = 0; i < _countFields; ++i)
            {
                if (_items[i].GetItemType() == ItemsEnum.Empty)
                {
                    _items[i] = item;
                    OnItemStored?.Invoke(i);
                    return;
                }
            }
        }
        
        /// <summary>
        /// Remove item from inventory.
        /// Replaces item at index with empty item.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveItem(int index)
        {
            _items[index] = new PermanentItem(ItemsEnum.Empty);
            OnItemStored?.Invoke(index);
        }
        
        /// <summary>
        /// Is inventory full.
        /// </summary>
        /// <returns>Does inventory have no empty space.</returns>
        public bool IsFull()
        {
            for (int i = 0; i < _countFields; ++i)
            {
                if (_items[i].GetItemType() == ItemsEnum.Empty)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
