using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Source.Core;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Source.Game
{
    public class InGameView : MonoBehaviour
    {
        private List<GameObject> _itemsOnScene;
        private GlobalInventory _globalInventory;
        private InGameItemFactory _inGameItemFactory;

        public void Init(GlobalInventory globalInventory, InGameItemFactory inGameItemFactory)
        {
            _globalInventory = globalInventory;
            _inGameItemFactory = inGameItemFactory;
            _itemsOnScene = new List<GameObject>();
            _globalInventory.OnItemSpawned += SpawnItem;
            _globalInventory.OnItemRemoved += RemoveItem;
            
            /*foreach (var item in _globalInventory._items)
            {
                var obj = _inGameItemFactory.CreateItem(item.GetItemType());
                if (obj.TryGetComponent(out ItemView view))
                {
                    view.Init(obj, item);
                    view.UpdatePosition(new Vector3(Random.Range(2, 7), Random.Range(2, 7), 0));
                }
                _itemsOnScene.Add(obj);
            }*/
        }

        private void SpawnItem(int index, Vector2 position)
        {
            var obj = _inGameItemFactory.CreateItem(_globalInventory._items[index].GetItemType());
            if (obj.TryGetComponent(out ItemView view))
            {
                view.Init(obj, _globalInventory._items[index]);
                Vector3 vector3 = new Vector3();
                vector3.x = position.x;
                vector3.y = position.y;
                vector3.z = 3;
                view.UpdatePosition(vector3);
            }
            _itemsOnScene.Add(obj);
        }
        
        private void RemoveItem(int index)
        {
            Destroy(_itemsOnScene[index]);         
            _itemsOnScene.RemoveAt(index);
        }
        
        public void RemoveItem(GameObject item)
        {
            _globalInventory.RemoveItem(_itemsOnScene.FindIndex(x => x == item));
        }
    }
}
