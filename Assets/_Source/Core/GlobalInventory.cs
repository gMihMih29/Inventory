using System;
using System.Collections;
using System.Collections.Generic;
using _Source.Core.Items;
using UnityEngine;

namespace _Source.Core
{
  public class GlobalInventory
  {
    public List<Item> _items = new List<Item>();
    public event System.Action<int, Vector2> OnItemSpawned;
    public event System.Action<int> OnItemRemoved;

    public void AddNewItem(Item item, Vector2 position)
    {
      _items.Add(item);
      OnItemSpawned?.Invoke(_items.Count - 1, position);
    }
    
    public void RemoveItem(int index)
    {
      _items.RemoveAt(index);
      OnItemRemoved?.Invoke(index);
    }
  }
}