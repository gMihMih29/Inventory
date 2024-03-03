using System.Collections;
using System.Collections.Generic;
using _Source.Core;
using _Source.Core.Items;
using UnityEngine;

public class ItemView : MonoBehaviour
{
    private Item _item;
    private GameObject _itemObject;
    
    public void Init(GameObject itemObject, Item item)
    {
        _item = item;
        _itemObject = itemObject;
    }
    
    public void UpdatePosition(Vector3 vector3)
    {
        transform.localPosition = vector3;
    }

    public ItemsEnum GetItemType()
    {
        return _item.GetItemType();
    }
}
