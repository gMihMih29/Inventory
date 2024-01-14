using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Source.Core;
using Unity.VisualScripting;
using UnityEngine;

namespace _Source.Game
{
    public class InventoryView : MonoBehaviour
    {
        private Inventory _inventory;
        private GameObject _inventoryObject;
        private ItemFactory _itemFactory;
        private List<GameObject> _items;
        private bool ininventory;
        public void Init(GameObject inventoryObject, Inventory inventory, ItemFactory itemFactory)
        {
            _inventory = inventory;
            _inventoryObject = inventoryObject;
            _itemFactory = itemFactory;
            _items = new List<GameObject>();
            _inventory.OnItemChanged += UpdateItem;
            int i = 0;
            foreach (var item in _inventory._items)
            {
                var obj = _itemFactory.CreateItem(item.GetItemType());
                                
                if (obj.TryGetComponent(out ItemView view))
                {
                    view.Init(obj, item);
                    view.UpdatePosition(new Vector3(i % 4, i / 4 , -100));
                    ++i;
                }
                _items.Add(obj);
            }
            Hide();
        }

        public void Show()
        {
            ininventory = true;
            UpdatePosition(new Vector3(0, 0, 0));
            int i = 0;
            foreach (var item in _items)
            {
                if (item.TryGetComponent(out ItemView view))
                {
                    view.UpdatePosition(new Vector3(i % 4, i / 4 , -1));
                    ++i;
                }
            }
        }

        public void Hide()
        {
            ininventory = false;
            UpdatePosition(new Vector3(0, 0, -100));
            int i = 0;
            foreach (var item in _items)
            {
                if (item.TryGetComponent(out ItemView view))
                {
                    view.UpdatePosition(new Vector3(i % 4, i / 4 , -100));
                    ++i;
                }
            }
        }
        
        void UpdatePosition(Vector3 vector3)
        {
            _inventoryObject.transform.position = vector3;
        }

        private void UpdateItem(int index)
        {
            var obj = _itemFactory.CreateItem(_inventory._items[index].GetItemType());
            var tmp = _items[index];
            _items[index] = obj;         
            Destroy(tmp);
            if (obj.TryGetComponent(out ItemView view))
            {
                view.Init(obj, _inventory._items[index]);
                view.UpdatePosition(new Vector3(index % 4, index / 4 , ininventory ? -1 : -100));
            }
        }
    }
}
