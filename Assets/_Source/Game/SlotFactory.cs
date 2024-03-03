using UnityEngine;

namespace _Source.Game
{
    public class SlotFactory : MonoBehaviour
    {
        [SerializeField]
        private GameObject _slotPrefab;
        
        public GameObject CreateSlot()
        {
            var obj = Instantiate(_slotPrefab);
            obj.AddComponent<DropOnSlotScript>();
            return obj;
        }
    }
}