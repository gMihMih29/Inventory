using System.Collections;
using System.Collections.Generic;
using _Source.Game.GlobalInventory;
using _Source.Game.Inventory;
using UnityEngine.EventSystems;
using UnityEngine;

namespace _Source.Game.PickUpAndDrop
{
    /// <summary>
    /// Drops item outside inventory that was dropped on owner of this script.
    /// Part of PickUpAndDrop feature.
    /// </summary>
    public class DropOutsideInventoryScript : MonoBehaviour, IDropHandler
    {
        [SerializeField] private InventorySpawner _inventorySpawner;
        [SerializeField] private GlobalInventorySpawner _globalInventorySpawner;
        
        void IDropHandler.OnDrop(PointerEventData eventData)
        {
            Vector2 position = _inventorySpawner.transform.parent.transform.position;
            position.x += 1.5f;
            _globalInventorySpawner.GetGlobalInventory().AddNewItem(eventData.pointerDrag.transform.gameObject.GetComponent<ItemView>().GetItem(), position);
            _inventorySpawner.GetInventoryView().RemoveItem(eventData.pointerDrag.transform.gameObject);
        }
    }
}
