using System;
using System.Collections.Generic;
using _Source.Core.Items;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace _Source.Game
{
  public class ItemFactory : MonoBehaviour
  {
    [SerializeField]
    private List<ItemScriptable> _items;
    
    public GameObject CreateItem(ItemsEnum itemType)
    {
      foreach (var item in _items)
      {
        if (item.GetItemType() == itemType)
        {
          return Instantiate(item.GetItemPrefab());
        }
      }
      return Instantiate(_items[0].GetItemPrefab());
    }
  }
}