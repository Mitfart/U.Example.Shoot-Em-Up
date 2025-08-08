using Misc;
using UnityEngine;

namespace Battle
{
    public class HitArea : CheckArea
    {
        public float damage;
        
        
        
        private void OnEnable() => OnHit += Damage;
        private void OnDisable() => OnHit += Damage;

        private void Damage(GameObject obj)
        {
            if (obj.TryGetComponent(out HurtArea hurtArea)) 
                hurtArea.ReceiveHit(damage);
            else 
                Destroy(gameObject);
        }
    }
}