using System;
using System.Collections.Generic;
using _Source.Core.Items;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Source.Game
{
    public class ItemFactory : MonoBehaviour
    {
        [SerializeField]
        private List<ItemScriptable> _items;
        
        public GameObject CreateItem(ItemsEnum itemType)
        {
            if (itemType == ItemsEnum.Empty)
            {
                return Instantiate(_items[0].GetItemPrefab());
            }

            GameObject obj = null;
            foreach (var item in _items)
            {
                if (item.GetItemType() == itemType)
                {
                    obj = Instantiate(item.GetItemPrefab());
                    obj.AddComponent<EventTrigger>();
                    obj.AddComponent<ItemDragHandler>();
                    break;
                }
            }
            return obj;
        }
    }
}