using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using _Source.Game;
using Unity.VisualScripting;
using UnityEngine;

namespace _Source.Game
{
    public class PickUpScript : MonoBehaviour
    {
        [SerializeField] private GameObject _inventorySpawner;
        [SerializeField] private GameObject _worldStorage;
        private static Mutex _mutex = new Mutex();

        private void OnTriggerEnter2D(Collider2D other)
        {
            var inventory = _inventorySpawner.GetComponent<InventorySpawner>().GetInventory();
            _mutex.WaitOne();
            if (!inventory.IsFull())
            {
                inventory.AddNewItem(other.gameObject.GetComponent<ItemView>().GetItem());
                _worldStorage.GetComponent<InGameView>().RemoveItem(other.gameObject);
            }
            _mutex.ReleaseMutex();
        }
    }
}
