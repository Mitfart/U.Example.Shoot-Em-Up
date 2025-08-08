using System.Collections.Generic;
using Infrastructure;
using Misc;
using UnityEngine;
using Random = UnityEngine.Random;

namespace @_.Items
{
    public class ItemDropper : Spawner<Item>
    {
        protected override string ContainerTag => "[ ITEMS ]";
        
        public List<Item> itemPrefabs;
        public Render render;
        public Vector2 offset;
        public float spawnTime;

        private float _lastSpawnTime;



        private void Update()
        {
            if (SpawnTime()) SpawnItem();
        }

        
        
        private bool SpawnTime()
        {
            return Time.time - spawnTime >= _lastSpawnTime;
        }

        private void SpawnItem()
        {
            _lastSpawnTime = Time.time;

            Spawn(
                RandomItem(), 
                RandomSpawnPos(), 
                Quaternion.identity
            );
        }

        
        private Item RandomItem()
        {
            return itemPrefabs[Random.Range(0, itemPrefabs.Count)];
        }

        private Vector2 RandomSpawnPos()
        {
            var boundaries = render.Boundaries - offset;
            var posX = Random.Range(-boundaries.x, boundaries.x);
            return new Vector2(posX, boundaries.y);
        }
    }
}