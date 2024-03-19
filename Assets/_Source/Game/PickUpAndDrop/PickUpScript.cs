using System.Threading;
using _Source.Game.GlobalInventory;
using _Source.Game.Inventory;
using UnityEngine;

namespace _Source.Game.PickUpAndDrop
{
    /// <summary>
    /// Pick up owner if collision with player occured and player has empty space in inventory.
    /// Part of PickUpAndDrop feature.
    /// </summary>
    public class PickUpScript : MonoBehaviour
    {  
        private GlobalInventoryView _worldStorageView;
        private static Mutex _mutex = new Mutex();

        public void Init(GlobalInventoryView worldStorageView)
        {
            _worldStorageView = worldStorageView;
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
                _worldStorageView.RemoveItem(gameObject);
            }
            _mutex.ReleaseMutex();
        }
    }
}
