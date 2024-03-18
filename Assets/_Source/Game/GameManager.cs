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
        }
    }
}
