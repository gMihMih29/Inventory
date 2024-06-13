using System.Collections.Generic;
using UnityEngine;

namespace _Source.Game.Inventory
{
    /// <summary>
    /// Contains logic of inventory visual appearance.
    /// </summary>
    public class InventoryView : MonoBehaviour
    {
        private List<GameObject> _slotsOnScene;
        private List<GameObject> _itemsOnScene;
        
        private Core.Inventories.Inventory _inventory;
        private InventoryItemFactory _inventoryItemFactory;
        private InventorySlotFactory _inventorySlotFactory;
        private Canvas _canvas;

        public void Init(GameObject inventoryObject, Core.Inventories.Inventory inventory, InventoryItemFactory inventoryItemFactory, InventorySlotFactory inventorySlotFactory, Canvas canvas)
        {
            _inventory = inventory;
            _inventoryItemFactory = inventoryItemFactory;
            _inventorySlotFactory = inventorySlotFactory;
            _canvas = canvas;
            _itemsOnScene = new List<GameObject>();
            _slotsOnScene = new List<GameObject>();
            _inventory.OnItemStored += StoreItem;
            _inventory.OnItemsSwapped += SwapItemsOnScene;
            for (int i = 0; i < _inventory._items.Count; ++i)
            {
                _slotsOnScene.Add(_inventorySlotFactory.CreateSlot());
                _slotsOnScene[i].transform.SetParent(inventoryObject.transform.GetChild(0));
                _slotsOnScene[i].transform.localPosition = new Vector3(i % 4 * 2, - i / 4 * 2, 0);
            }
            int curSlot = 0;
            foreach (var item in _inventory._items)
            {
                var obj = _inventoryItemFactory.CreateItem(item.GetItemType(), _canvas, this);          
                if (obj.TryGetComponent(out ItemView view))
                {
                    obj.transform.SetParent(_slotsOnScene[curSlot].transform);
                    view.Init(item);
                    view.UpdatePosition(Vector3.zero);
                    ++curSlot;
                }
                _itemsOnScene.Add(obj);
            }
            Hide();
        }

        /// <summary>
        /// Show inventory on player screen.
        /// </summary>
        public void Show()
        {
            UpdatePosition(new Vector3(0, 0, 0));
            int i = 0;
            foreach (var item in _itemsOnScene)
            {
                if (item.TryGetComponent(out ItemView view))
                {
                    view.UpdatePosition(Vector3.zero);
                    ++i;
                }
            }
        }

        /// <summary>
        /// Remove inventory from player screen.
        /// </summary>
        public void Hide()
        {
            UpdatePosition(new Vector3(0, 0, -100));
            int i = 0;
            foreach (var item in _itemsOnScene)
            {
                if (item.TryGetComponent(out ItemView view))
                {
                    view.UpdatePosition(Vector3.zero);
                    ++i;
                }
            }
        }
        
        void UpdatePosition(Vector3 vector3)
        {
            _canvas.transform.localPosition = vector3;
        }

        /// <summary>
        /// Swaps items between given slots.
        /// </summary>
        /// <param name="slot1">First slot.</param>
        /// <param name="slot2">Second slot.</param>
        public void SwapItemsBySlots(GameObject slot1, GameObject slot2)
        {
            var index1 = _slotsOnScene.FindIndex(x => x == slot1);
            var index2 = _slotsOnScene.FindIndex(x => x == slot2);
            _inventory.SwapItems(index1, index2);
        }

        /// <summary>
        /// Visual. Swaps items by indexes in inventory.
        /// </summary>
        /// <param name="index">Index of first item.</param>
        /// <param name="other">Index of second item.</param>
        private void SwapItemsOnScene(int index, int other)
        {
            (_itemsOnScene[index], _itemsOnScene[other]) = (_itemsOnScene[other], _itemsOnScene[index]);
            if (_itemsOnScene[index].TryGetComponent(out ItemView view))
            {
                _itemsOnScene[index].transform.SetParent(_slotsOnScene[index].transform);
                view.UpdatePosition(Vector3.zero);
            }
            if (_itemsOnScene[other].TryGetComponent(out ItemView viewOther))
            {
                _itemsOnScene[other].transform.SetParent(_slotsOnScene[other].transform);
                viewOther.UpdatePosition(Vector3.zero);
            }
        }

        /// <summary>
        /// Visual. Store item by index in inventory.
        /// </summary>
        /// <param name="index">Index of item.</param>
        private void StoreItem(int index)
        {
            var obj = _inventoryItemFactory.CreateItem(_inventory._items[index].GetItemType(), _canvas, this);
            var tmp = _itemsOnScene[index];
            _itemsOnScene[index] = obj;         
            Destroy(tmp);
            if (obj.TryGetComponent(out ItemView view))
            {
                obj.transform.SetParent(_slotsOnScene[index].transform);
                view.Init(_inventory._items[index]);
                view.UpdatePosition(Vector3.zero);
            }
        }
        
        /// <summary>
        /// Removes item by game object.
        /// </summary>
        /// <param name="item">Game object of item.</param>
        public void RemoveItem(GameObject item)
        {
            _inventory.RemoveItem(_itemsOnScene.FindIndex(x => x == item));
        }
    }
}
