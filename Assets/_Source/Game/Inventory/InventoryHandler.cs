using UnityEngine;

namespace _Source.Game.Inventory
{
    /// <summary>
    /// Handles player input related to inventory.
    /// </summary>
    public class InventoryHandler : MonoBehaviour
    {
        public static bool InInventory = false;
        [SerializeField] private InventorySpawner _inventorySpawner;
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InInventory = !InInventory;
                if (InInventory)
                {
                    _inventorySpawner.GetInventoryView().Show();
                }
                else
                {
                    _inventorySpawner.GetInventoryView().Hide();
                }
            }
        }
    }
}
