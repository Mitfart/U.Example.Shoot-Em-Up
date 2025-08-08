using Battle;
using UnityEngine;

namespace Shooting
{
    [RequireComponent(typeof(HitArea))]
    public class Bullet : MonoBehaviour
    {
        public HitArea hitArea;
        

        
        private void OnEnable() => hitArea.OnHit += DestroySelf;
        private void OnDisable() => hitArea.OnHit -= DestroySelf;

        public void Init(LayerMask collisionMask, float damage)
        { 
            hitArea.collisionMask = collisionMask;
            hitArea.damage *= damage;
        }
        
        private void DestroySelf(GameObject obj)
        {
            Destroy(gameObject);
        }
    }
}