using System.Collections;
using System.Collections.Generic;
using _Source.Core;
using UnityEngine;

public class ItemView : MonoBehaviour
{
    private bool _inInventory;
    private Item _item;
    private GameObject _itemObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Init(GameObject inventoryObject, Inventory inventory)
    {

    }
    
    private void UpdatePosition(Vector3 vector3)
    {
        transform.position = vector3;
    }
}
