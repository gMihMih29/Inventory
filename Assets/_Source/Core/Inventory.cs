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
        public event System.Action<int> OnItemChanged;

        public Inventory(int countFields = 8)
        {
            _countFields = countFields;
            _items = new List<Item>();
            for (int i = 0; i < countFields; ++i)
            {
                _items.Add(new PermanentItem(ItemsEnum.Empty));
            }
        }

        public void ChangePositionOf(Item item, int newIndex)
        {
            int oldIndex = _items.FindIndex(x => x == item);
            if (_items[newIndex].GetItemType() == ItemsEnum.Empty)
            {
                _items[newIndex] = item;
                _items[oldIndex] = new PermanentItem(ItemsEnum.Empty);
            }
            else
            {
                Item tmp = _items[newIndex];
                _items[newIndex] = item;
                _items[oldIndex] = tmp;
            }
            OnItemChanged?.Invoke(newIndex);
            OnItemChanged?.Invoke(oldIndex);
        }

        public void AddItem(Item item)
        {
            for (int i = 0; i < _countFields; ++i)
            {
                if (_items[i].GetItemType() == ItemsEnum.Empty)
                {
                    _items[i] = item;
                    OnItemChanged?.Invoke(i);
                    return;
                }
            }
            throw new ArgumentException();
        }
    }
}
