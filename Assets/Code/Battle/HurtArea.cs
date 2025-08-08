using System;
using Extensions;
using UnityEngine;

namespace Battle
{
    [RequireComponent(typeof(Collider2D))]
    public class HurtArea : MonoBehaviour
    {
        public Action<float> OnHurt;
        
        [Min(Consts.EPSILON)] public float invincibilityDuration = Consts.EPSILON;

        private float _damageTime;

        public bool Invincible => Time.time - _damageTime < invincibilityDuration;

        

        private void Awake()
        {
            _damageTime = Time.time + invincibilityDuration * 2f; // FIX ERROR: Player Invincible On Start
        }

        public void ReceiveHit(float damage)
        {
            if (Invincible) return;
            
            _damageTime = Time.time;
            OnHurt?.Invoke(damage);
        }
    }
}