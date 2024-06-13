using _Source.Game.GlobalInventory;
using _Source.Game.Inventory;
using UnityEngine;

namespace _Source.Game
{
    /// <summary>
    /// Main class for inventory logic.
    /// Initializes spawners of inventories.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private InventorySpawner _inventorySpawner;
        [SerializeField] private GlobalInventorySpawner _globalInventorySpawner;

        private void Awake()
        {
            _globalInventorySpawner.Init();
            _inventorySpawner.Init();
        }
    }
}
