using UnityEngine;

namespace Misc
{
    public class LifeSpan : MonoBehaviour
    {
        public float lifeTime;
        
        private float _spawnTime;
        
        public float PassedTime => Time.time - _spawnTime;


        
        private void Awake() => _spawnTime = Time.time;

        private void Update()
        {
            if (PassedTime < lifeTime) return;
            
            Destroy(gameObject);
        }
    }
}