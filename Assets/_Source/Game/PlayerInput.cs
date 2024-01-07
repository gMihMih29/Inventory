using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.Game
{
    public class PlayerInput : MonoBehaviour
    {
        public float _speed;
        public GameObject _player;

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
                    _player.transform.position += _speed * Time.deltaTime * (Vector3.up);
                }

                if (Input.GetKey(KeyCode.A))
                {
                    _player.transform.position += _speed * Time.deltaTime * (Vector3.left);
                }

                if (Input.GetKey(KeyCode.S))
                {
                    _player.transform.position += _speed * Time.deltaTime * (Vector3.down);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    _player.transform.position += _speed * Time.deltaTime * (Vector3.right);
                }
            }
        }
    }
}