using System;
using System.Collections;
using System.Collections.Generic;
using _Source.Core.Items;
using UnityEngine;

namespace _Source.Core
{
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
        
        public void SwapItems(int index, int otherIndex)
        {
            (_items[index], _items[otherIndex]) = (_items[otherIndex], _items[index]);
            OnItemsSwapped?.Invoke(index, otherIndex);
        }

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
        
        public void RemoveItem(int index)
        {
            _items[index] = new PermanentItem(ItemsEnum.Empty);
            OnItemStored?.Invoke(index);
        }
        
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
