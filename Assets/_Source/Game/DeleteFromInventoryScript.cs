using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

namespace _Source.Game
{
  public class DeleteFromInventoryScript : MonoBehaviour, IDropHandler
  {
    [SerializeField] private InventorySpawner _inventorySpawner;
        
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
      _inventorySpawner.GetInventoryView().RemoveItem(eventData.pointerDrag.transform.gameObject);
    }
  }
}