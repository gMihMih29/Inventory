using _Source.Game.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Source.Game.DragAndDrop
{
    /// <summary>
    /// Script of dropping items on slots.
    /// Part of DragAndDrop feature.
    /// </summary>
    public class DropOnItemScript : MonoBehaviour, IDropHandler
    {
        private InventoryView _inventoryView;

        public void Init(InventoryView iv)
        {
            _inventoryView = iv;
        }

        void IDropHandler.OnDrop(PointerEventData eventData)
        {
            var oldParent = eventData.pointerDrag.transform.parent.gameObject;
            var newParent = gameObject.transform.parent.gameObject;
            _inventoryView.SwapItemsBySlots(oldParent, newParent);
        }
    }
}