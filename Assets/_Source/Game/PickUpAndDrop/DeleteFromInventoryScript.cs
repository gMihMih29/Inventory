using _Source.Game.Inventory;
using UnityEngine.EventSystems;
using UnityEngine;

namespace _Source.Game.PickUpAndDrop
{
    /// <summary>
    /// Deletes item that was dropped on owner of this script.
    /// Part of PickUpAndDrop feature.
    /// </summary>
    public class DeleteFromInventoryScript : MonoBehaviour, IDropHandler
    {
        [SerializeField] private InventorySpawner _inventorySpawner;

        void IDropHandler.OnDrop(PointerEventData eventData)
        {
            _inventorySpawner.GetInventoryView().RemoveItem(eventData.pointerDrag.transform.gameObject);
        }
    }
}