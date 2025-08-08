using System;
using UnityEngine;

namespace Battle
{
    [RequireComponent(typeof(HurtArea), typeof(Health))]
    public class Entity : MonoBehaviour, IDisposable
    {
        public event Action<Entity> OnDie;

        public Health health;


        
        private void OnEnable() => health.OnZero += Die;
        private void OnDisable() => health.OnZero -= Die;
        
        

        public void Die()
        {
            OnDie?.Invoke(this);
            
            Dispose();
        }
        
        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}