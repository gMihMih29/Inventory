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
        [SerializeField]
        private List<GameObject> _cells;
        
        private Inventory _inventory;
        private GameObject _inventoryObject;
        private ItemFactory _itemFactory;
        private List<GameObject> _items;

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
                    obj.transform.parent = _inventoryObject.GetComponentInChildren<Canvas>().transform;
                    view.Init(obj, item);
                    view.UpdatePosition(_cells[i].transform.position);
                    ++i;
                }
                _items.Add(obj);
            }
            Hide();
        }

        public void Show()
        {
            UpdatePosition(new Vector3(0, 0, 0));
            int i = 0;
            foreach (var item in _items)
            {
                if (item.TryGetComponent(out ItemView view))
                {
                    view.UpdatePosition(_cells[i].transform.position);
                    ++i;
                }
            }
        }

        public void Hide()
        {
            UpdatePosition(new Vector3(0, 0, -100));
            int i = 0;
            foreach (var item in _items)
            {
                if (item.TryGetComponent(out ItemView view))
                {
                    view.UpdatePosition(_cells[i].transform.position);
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
                obj.transform.parent = _inventoryObject.GetComponentInChildren<Canvas>().transform;
                view.Init(obj, _inventory._items[index]);
                view.UpdatePosition(_cells[index].transform.position + Vector3.up);
            }
        }
    }
}
