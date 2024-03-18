using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using _Source.Core;
using _Source.Core.Items;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Source.Game
{
    public class ItemGeneratorScript : MonoBehaviour
    {
        [SerializeField] private GlobalInventorySpawner _globalInventorySpawner;
        [SerializeField] private float _radius = 3;
        [SerializeField] private float _deltaTime = 5;
        private float _lastUpdate;

        // Start is called before the first frame update
        private void Start()
        {
            _lastUpdate = Time.time;
        }

        private Item GenerateItem()
        {
            int index = Random.Range(1, Enum.GetValues(typeof(ItemsEnum)).Cast<int>().Max() + 1);
            return new PermanentItem((ItemsEnum)index);
        }

        private Vector2 GeneratePosition()
        {
            float angle = Random.Range(0.0f, (float)(2 * Math.PI));
            float x = (float)Math.Sin(angle);
            float y = (float)Math.Cos(angle);
            Vector2 position = transform.position;
            position += new Vector2(x, y) * Random.Range(1, _radius);
            return position;
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time - _lastUpdate > _deltaTime)
            {
                _globalInventorySpawner.GetGlobalInventory().AddNewItem(GenerateItem(), GeneratePosition());
                _lastUpdate = Time.time;
            }
        }
    }
}