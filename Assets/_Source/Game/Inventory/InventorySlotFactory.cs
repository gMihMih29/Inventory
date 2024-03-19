using UnityEngine;

namespace _Source.Game.Inventory
{
    /// <summary>
    /// Creates game objects of slot for player inventory.
    /// </summary>
    public class InventorySlotFactory : MonoBehaviour
    {
        [SerializeField]
        private GameObject _slotPrefab;
        
        /// <summary>
        /// Create slot for inventory.
        /// </summary>
        /// <returns>Game object of slot.</returns>
        public GameObject CreateSlot()
        {
            var obj = Instantiate(_slotPrefab);
            return obj;
        }
    }
}