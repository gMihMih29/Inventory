using System.Collections;
using System.Collections.Generic;
using _Source.Core;
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
        transform.position = vector3;
    }
}
