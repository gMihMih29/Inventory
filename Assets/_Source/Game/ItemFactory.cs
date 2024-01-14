using System;
using System.Collections.Generic;
using _Source.Core.Items;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace _Source.Game
{
  public class ItemFactory : MonoBehaviour
  {
    [SerializeField]
    private List<ItemScriptable> _items;
  }
}