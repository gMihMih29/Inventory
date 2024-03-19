using _Source.Game.Inventory;
using UnityEngine;

namespace _Source.Game
{
    /// <summary>
    /// Controls player movement.
    /// </summary>
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private float _speed;

        
        void Update()
        {
            Vector3 newPosition = transform.position;
            
            if (!InventoryHandler.InInventory)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    newPosition += _speed * Time.deltaTime * (Vector3.up);
                }

                if (Input.GetKey(KeyCode.A))
                {
                    newPosition += _speed * Time.deltaTime * (Vector3.left);
                }

                if (Input.GetKey(KeyCode.S))
                {
                    newPosition += _speed * Time.deltaTime * (Vector3.down);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    newPosition += _speed * Time.deltaTime * (Vector3.right);
                }
                transform.position = newPosition;
                transform.rotation = Quaternion.Euler(Vector3.zero);
            }
        }
    }
}