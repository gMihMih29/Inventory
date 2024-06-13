using _Source.Core.Items;
using UnityEngine;

namespace _Source.Game
{
    /// <summary>
    /// View of item on scene.
    /// </summary>
    public class ItemView : MonoBehaviour
    {
        private Item _item;

        public void Init(Item item)
        {
            _item = item;
        }

        public void UpdatePosition(Vector3 vector3)
        {
            transform.localPosition = vector3;
        }

        /// <summary>
        /// Return item that is related to owner.
        /// </summary>
        /// <returns>Item.</returns>
        public Item GetItem()
        {
            return _item;
        }
    }
}
