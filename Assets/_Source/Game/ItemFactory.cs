using System;
using System.Collections.Generic;
using _Source.Core.Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Source.Game
{
    public class ItemFactory : MonoBehaviour
    {
        [SerializeField]
        private List<ItemScriptable> _items;
        
        public GameObject CreateItem(ItemsEnum itemType, Canvas canvas, InventoryView view)
        {
            GameObject obj = null;
            if (itemType == ItemsEnum.Empty)
            {
                obj = Instantiate(_items[0].GetItemPrefab());
                obj.AddComponent<DropOnItemScript>();
                obj.GetComponent<DropOnItemScript>().Init(view);
                return obj;
            }

            
            foreach (var item in _items)
            {
                if (item.GetItemType() == itemType)
                {
                    obj = Instantiate(item.GetItemPrefab());
                    obj.AddComponent<EventTrigger>();
                    obj.AddComponent<DragScript>();
                    obj.AddComponent<DropOnItemScript>();
                    obj.GetComponent<DropOnItemScript>().Init(view);
                    obj.GetComponent<DragScript>().Init(canvas);
                    break;
                }
            }
            return obj;
        }
    }
}