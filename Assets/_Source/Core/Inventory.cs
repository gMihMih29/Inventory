using System.Collections;
using System.Collections.Generic;
using _Source.Core.Items;
using UnityEngine;

namespace _Source.Core
{
    public class Inventory
    {
        private int _countFields;
        private List<Item> _items;

        public Inventory(int countFields = 8)
        {
            _countFields = countFields;
            _items = new List<Item>(countFields);
        }

        public void ChangePositionOf(Item item, int newIndex)
        {
            int oldIndex = _items.FindIndex(x => x == item);
            if (_items[newIndex] is Empty)
            {
                _items[newIndex] = item;
                _items[oldIndex] = new Empty();
            }
            else
            {
                Item tmp = _items[newIndex];
                _items[newIndex] = item;
                _items[oldIndex] = tmp;
            }
        }
    }
}
