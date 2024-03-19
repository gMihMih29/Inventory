using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.Game
{
    public class InventoryHandler : MonoBehaviour
    {
        public static bool InInventory = false;
        [SerializeField] private GameObject _inventorySpawner;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                InInventory = !InInventory;
                if (InInventory)
                {
                    _inventorySpawner.GetComponent<InventorySpawner>()?.ShowInventory();
                }
                else
                {
                    _inventorySpawner.GetComponent<InventorySpawner>()?.HideInventory();
                }
            }
        }
    }
}
