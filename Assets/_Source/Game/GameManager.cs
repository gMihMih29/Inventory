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

        private void Awake()
        {
            _inventorySpawner.GetComponent<InventorySpawner>()?.Init();
            var inventory = _inventorySpawner.GetComponent<InventorySpawner>()?.GetInventory();
            inventory.AddNewItem(new PermanentItem(ItemsEnum.Wood, 3, "Oak wood", "it is oak wood."));
            inventory.AddNewItem(new PermanentItem(ItemsEnum.Gold, 3, "Gold", "it is gold."));
            inventory.AddNewItem(new PermanentItem(ItemsEnum.Gold, 5, "Gold", "it is gold."));
            inventory.AddNewItem(new PermanentItem(ItemsEnum.Meat, 1, "Meat", "it is meat."));
            inventory.AddNewItem(new PermanentItem(ItemsEnum.Meat, 2, "Raw meat", "it is raw meat."));
        }
    }
}
