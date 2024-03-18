using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.Game
{
    public class PlayerInput : MonoBehaviour
    {
        public float _speed;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!InventoryHandler.InInventory)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.position += _speed * Time.deltaTime * (Vector3.up);
                }

                if (Input.GetKey(KeyCode.A))
                {
                    transform.position += _speed * Time.deltaTime * (Vector3.left);
                }

                if (Input.GetKey(KeyCode.S))
                {
                    transform.position += _speed * Time.deltaTime * (Vector3.down);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += _speed * Time.deltaTime * (Vector3.right);
                }
            }
        }
    }
}