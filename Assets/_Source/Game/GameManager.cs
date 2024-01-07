using System;
using System.Collections;
using System.Collections.Generic;
using _Source.Core;
using UnityEngine;

namespace _Source.Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _inventorySpawner;

        private void Awake()
        {
            _inventorySpawner.GetComponent<InventorySpawner>()?.Init();
        }
    }
}
