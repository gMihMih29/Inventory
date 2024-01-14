using System.Collections;
using System.Collections.Generic;
using _Source.Core;
using UnityEngine;

namespace _Source.Game
{
    public class InventorySpawner : MonoBehaviour
    {
        private Inventory _inventory;
        [SerializeField] private GameObject _inventoryPrefab;
        private GameObject _inventoryObject;
        [SerializeField] private GameObject _itemFactory;

        public void Init()
        {
            _inventory = new Inventory();
            _inventoryObject = Instantiate(_inventoryPrefab);
            if (_inventoryObject.TryGetComponent(out InventoryView view))
            {
                view.Init(_inventoryObject, _inventory, _itemFactory.GetComponent<ItemFactory>());
            }
        }

        public Inventory GetInventory()
        {
            return _inventory;
        }
        
        public void ShowInventory()
        {
            if (_inventoryObject.TryGetComponent(out InventoryView view))
            {
                view.Show();
            }
        }

        public void HideInventory()
        {
            if (_inventoryObject.TryGetComponent(out InventoryView view))
            {
                view.Hide();
            }
        }
    }
}
