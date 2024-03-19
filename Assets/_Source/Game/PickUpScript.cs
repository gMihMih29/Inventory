using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using _Source.Core.Items;
using _Source.Game;
using Unity.VisualScripting;
using UnityEngine;

namespace _Source.Game
{
    public class PickUpScript : MonoBehaviour
    {  
        private InGameView _worldStorage;
        private static Mutex _mutex = new Mutex();

        public void Init(InGameView worldStorage)
        {
            _worldStorage = worldStorage;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag != "Player")
            {
                return;
            }
            var inventory = other.transform.gameObject.GetComponentInChildren<InventorySpawner>().GetInventory();
            _mutex.WaitOne();
            if (!inventory.IsFull())
            {
                inventory.AddNewItem(gameObject.GetComponent<ItemView>().GetItem());
                _worldStorage.RemoveItem(gameObject);
            }
            _mutex.ReleaseMutex();
        }
    }
}
