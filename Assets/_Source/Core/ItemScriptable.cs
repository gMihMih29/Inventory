using UnityEngine;

namespace _Source.Core.Items
{
  [CreateAssetMenu(menuName="SO/new Item", fileName="Item")]
  public class ItemScriptable : ScriptableObject
  {
    [SerializeField] private ItemsEnum _type;
    [SerializeField] private GameObject _itemPrefab;

    public ItemsEnum GetItemType()
    {
      return _type;
    }
   
    public GameObject GetItemPrefab()
    {
      return _itemPrefab;
    }
  }
}