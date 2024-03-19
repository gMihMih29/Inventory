using System.Collections.Generic;
using _Source.Core.Items;
using _Source.Core.ItemsScriptable;
using _Source.Game.DragAndDrop;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Source.Game.Inventory
{
    /// <summary>
    /// Creates game objects of items for player inventory.
    /// </summary>
    public class InventoryItemFactory : MonoBehaviour
    {
        [SerializeField]
        private List<ItemScriptable> _items;
        
        /// <summary>
        /// Create item.
        /// </summary>
        /// <param name="itemType">Type of item.</param>
        /// <param name="canvas">Canvas for item.</param>
        /// <param name="view">Inventory view.</param>
        /// <returns>Game object of item.</returns>
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