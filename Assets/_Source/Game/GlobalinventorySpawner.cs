using System.Collections;
using System.Collections.Generic;
using _Source.Core;
using UnityEngine;

namespace _Source.Game
{
  public class GlobalInventorySpawner : MonoBehaviour
  {
    private GlobalInventory _globalInventory;
    [SerializeField] private GameObject _inGameItemFactory;
    [SerializeField] private GameObject _worldStorage;
    
    public void Init()
    {
      _globalInventory = new GlobalInventory();
      
      if (_worldStorage.TryGetComponent(out InGameView view))
      {
        view.Init(
          _globalInventory, 
          _inGameItemFactory.GetComponent<InGameItemFactory>()
        );
      }
    }

    public GlobalInventory GetGlobalInventory()
    {
      return _globalInventory;
    }
  }
}