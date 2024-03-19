using System;
using System.Collections.Generic;
using _Source.Core.Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

namespace _Source.Game
{
  public class InGameItemFactory : MonoBehaviour
  {
    [SerializeField] private List<ItemScriptable> _items;
        
    public GameObject CreateItem(ItemsEnum itemType, InGameView worldStorage)
    {
      GameObject obj = null;
            
      foreach (var item in _items)
      {
        if (item.GetItemType() == itemType)
        {
          obj = Instantiate(item.GetItemPrefab());
          var pickUpScript = obj.GetComponent<PickUpScript>();
          pickUpScript.Init(worldStorage);
          break;
        }
      }
      return obj;
    }
  }
}