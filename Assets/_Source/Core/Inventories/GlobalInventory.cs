using System.Collections.Generic;
using _Source.Core.Items;
using UnityEngine;

namespace _Source.Core.Inventories
{
    /// <summary>
    /// Represents all items that exists inside world inventory system.
    /// </summary>
    public class GlobalInventory
    {
        public List<Item> _items = new List<Item>();
        public event System.Action<int, Vector2> OnItemSpawned;
        public event System.Action<int> OnItemRemoved;

        /// <summary>
        /// Add new item to world inventory system.
        /// </summary>
        /// <param name="item">New item.</param>
        /// <param name="position">Position of new item.</param>
        public void AddNewItem(Item item, Vector2 position)
        {
          _items.Add(item);
          OnItemSpawned?.Invoke(_items.Count - 1, position);
        }
        
        /// <summary>
        /// Remove item from world inventory system
        /// </summary>
        /// <param name="index">Index of item to remove.</param>
        public void RemoveItem(int index)
        {
          _items.RemoveAt(index);
          OnItemRemoved?.Invoke(index);
        }
    }
}