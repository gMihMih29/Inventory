using System.Collections.Generic;
using UnityEngine;

namespace _Source.Game.GlobalInventory
{
    /// <summary>
    /// Contains logic of inventory visual appearance.
    /// </summary>
    public class GlobalInventoryView : MonoBehaviour
    {
        private List<GameObject> _itemsOnScene;
        private Core.Inventories.GlobalInventory _globalInventory;
        private GlobalItemFactory _globalItemFactory;

        public void Init(Core.Inventories.GlobalInventory globalInventory, GlobalItemFactory globalItemFactory)
        {
            _globalInventory = globalInventory;
            _globalItemFactory = globalItemFactory;
            _itemsOnScene = new List<GameObject>();
            _globalInventory.OnItemSpawned += SpawnItem;
            _globalInventory.OnItemRemoved += RemoveItem;
        }

        /// <summary>
        /// Spawns item in world at position.
        /// </summary>
        /// <param name="index">Index of item to spawn.</param>
        /// <param name="position">Position of item.</param>
        public void SpawnItem(int index, Vector2 position)
        {
            var obj = _globalItemFactory.CreateItem(_globalInventory._items[index].GetItemType(),this);
            if (obj.TryGetComponent(out ItemView view))
            {
                view.Init(_globalInventory._items[index]);
                Vector3 vector3 = new Vector3();
                vector3.x = position.x;
                vector3.y = position.y;
                vector3.z = 3;
                view.UpdatePosition(vector3);
            }
            _itemsOnScene.Add(obj);
        }
        
        /// <summary>
        /// Remove item from world.
        /// </summary>
        /// <param name="index">Index of item.</param>
        private void RemoveItem(int index)
        {
            Destroy(_itemsOnScene[index]);         
            _itemsOnScene.RemoveAt(index);
        }
        
        /// <summary>
        /// Remove item from world.
        /// </summary>
        /// <param name="item">Item on scene.</param>
        public void RemoveItem(GameObject item)
        {
            _globalInventory.RemoveItem(_itemsOnScene.FindIndex(x => x == item));
        }
    }
}
