using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.Game
{
    public class PlayerInput : MonoBehaviour
    {
        public float _speed;

        // Update is called once per frame
        void Update()
        {
            
            Vector2 newPosition = transform.position;
            
            if (!InventoryHandler.InInventory)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    newPosition += _speed * Time.deltaTime * (Vector2.up);
                }

                if (Input.GetKey(KeyCode.A))
                {
                    newPosition += _speed * Time.deltaTime * (Vector2.left);
                }

                if (Input.GetKey(KeyCode.S))
                {
                    newPosition += _speed * Time.deltaTime * (Vector2.down);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    newPosition += _speed * Time.deltaTime * (Vector2.right);
                }
                transform.position = newPosition;
                Quaternion rotation = new Quaternion();
                rotation.eulerAngles = Vector3.zero;
                transform.rotation = rotation;
            }
        }
    }
}