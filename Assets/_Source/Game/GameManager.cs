using System;
using System.Collections;
using System.Collections.Generic;
using _Source.Core;
using _Source.Core.Items;
using UnityEngine;

namespace _Source.Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _inventorySpawner;
        [SerializeField] private GameObject _globalInventorySpawner;

        private void Awake()
        {
            _globalInventorySpawner.GetComponent<GlobalInventorySpawner>()?.Init();
            _inventorySpawner.GetComponent<InventorySpawner>()?.Init();
            var inventory = _inventorySpawner.GetComponent<InventorySpawner>()?.GetInventory();
            var globalInventory = _globalInventorySpawner.GetComponent<GlobalInventorySpawner>()?.GetGlobalInventory();
            globalInventory.AddNewItem(new PermanentItem(ItemsEnum.Wood, 3, "Oak wood", "it is oak wood."), new Vector2(1, 0));
            globalInventory.AddNewItem(new PermanentItem(ItemsEnum.Stone, 3, "Stone", "This is stone. That's it."), new Vector2(1, 1));
            globalInventory.AddNewItem(new PermanentItem(ItemsEnum.Stone, 3, "Stone", "This is stone. That's it."), new Vector2(0, 1));
            globalInventory.AddNewItem(new PermanentItem(ItemsEnum.Meat, 3, "Meat", "It is meat."), new Vector2(1, 0));
            
            inventory.AddNewItem(new PermanentItem(ItemsEnum.Wood, 3, "Oak wood", "it is oak wood."));
            inventory.AddNewItem(new PermanentItem(ItemsEnum.Gold, 3, "Gold", "it is gold."));
            inventory.AddNewItem(new PermanentItem(ItemsEnum.Gold, 5, "Gold", "it is gold."));
            inventory.AddNewItem(new PermanentItem(ItemsEnum.Meat, 1, "Meat", "it is meat."));
            inventory.AddNewItem(new PermanentItem(ItemsEnum.Meat, 2, "Raw meat", "it is raw meat."));
        }
    }
}
