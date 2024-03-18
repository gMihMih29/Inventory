using System;
using System.Collections.Generic;
using _Source.Core.Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Source.Game
{
  public class InGameItemFactory : MonoBehaviour
  {
    [SerializeField] private List<ItemScriptable> _items;
        
    public GameObject CreateItem(ItemsEnum itemType)
    {
      GameObject obj = null;
            
      foreach (var item in _items)
      {
        if (item.GetItemType() == itemType)
        {
          obj = Instantiate(item.GetItemPrefab());
          break;
        }
      }
      return obj;
    }
  }
}