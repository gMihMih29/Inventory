using System.Collections.Generic;
using _Source.Core.Items;
using _Source.Core.ItemsScriptable;
using _Source.Game.PickUpAndDrop;
using UnityEngine;

namespace _Source.Game.GlobalInventory
{
    /// <summary>
    /// Creates game objects of items for world inventory system.
    /// </summary>
    public class GlobalItemFactory : MonoBehaviour
    {
        [SerializeField] private List<ItemScriptable> _items;

        /// <summary>
        /// Create game object of item.
        /// </summary>
        /// <param name="itemType">Type of item.</param>
        /// <param name="worldStorage">World inventory system.</param>
        /// <returns>Game object of item.</returns>
        public GameObject CreateItem(ItemsEnum itemType, GlobalInventoryView worldStorage)
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