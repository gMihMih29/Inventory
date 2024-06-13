using UnityEngine;

namespace _Source.Game.Inventory
{
    /// <summary>
    /// Spawns player inventory.
    /// </summary>
    public class InventorySpawner : MonoBehaviour
    {
        private Core.Inventories.Inventory _inventory;
        [SerializeField] private GameObject _inventoryPrefab;
        private GameObject _inventoryObject;
        [SerializeField] private InventoryItemFactory _itemFactory;
        [SerializeField] private InventorySlotFactory _slotFactory;
        [SerializeField] private Canvas _inventoryCanvas;
        [SerializeField] private int _inventorySize;
        public void Init()
        {
            _inventory = new Core.Inventories.Inventory(_inventorySize);
            _inventoryObject = Instantiate(_inventoryPrefab);
            _inventoryObject.transform.SetParent(_inventoryCanvas.transform);
            _inventoryObject.transform.localPosition = Vector3.zero;
            if (_inventoryObject.TryGetComponent(out InventoryView view))
            {
                view.Init(
                    _inventoryObject, 
                    _inventory, 
                    _itemFactory, 
                    _slotFactory,
                    _inventoryCanvas
                );
            }
        }

        public Core.Inventories.Inventory GetInventory()
        {
            return _inventory;
        }

        public InventoryView GetInventoryView()
        {
            return _inventoryObject.GetComponent<InventoryView>();
        }
    }
}
