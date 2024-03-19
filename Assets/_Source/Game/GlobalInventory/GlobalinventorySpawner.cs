using UnityEngine;

namespace _Source.Game.GlobalInventory
{
    /// <summary>
    /// Creates global inventory.
    /// </summary>
    public class GlobalInventorySpawner : MonoBehaviour
    {
        private Core.Inventories.GlobalInventory _globalInventory;
        [SerializeField] private GlobalItemFactory _globalItemFactory;
        [SerializeField] private GlobalInventoryView _worldStorageView;

        public void Init()
        {
            _globalInventory = new Core.Inventories.GlobalInventory();

            _worldStorageView.Init(
                _globalInventory, 
                _globalItemFactory
            );
        }

        public Core.Inventories.GlobalInventory GetGlobalInventory()
        {
            return _globalInventory;
        }
    }
}