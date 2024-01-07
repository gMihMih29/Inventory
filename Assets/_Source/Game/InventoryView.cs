using System.Collections;
using System.Collections.Generic;
using _Source.Core;
using UnityEngine;

namespace _Source.Game
{
    public class InventoryView : MonoBehaviour
    {
        private Inventory _inventory;
        private GameObject _inventoryObject;
        public void Init(GameObject inventoryObject, Inventory inventory)
        {
            _inventory = inventory;
            _inventoryObject = inventoryObject;
            Hide();
        }

        public void Show()
        {
            UpdatePosition(new Vector3(0, 0, 0));
        }

        public void Hide()
        {
            UpdatePosition(new Vector3(0, 0, -100));
        }
        
        // Update is called once per frame
        void UpdatePosition(Vector3 vector3)
        {
            _inventoryObject.transform.position = vector3;
        }
    }
}
