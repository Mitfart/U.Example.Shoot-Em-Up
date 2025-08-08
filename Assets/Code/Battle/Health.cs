using System;
using UnityEngine;

namespace Battle
{
    public class Health : MonoBehaviour
    {
        public event Action<float> OnDamage;
        public event Action OnZero;

        public float value;

        

        public void Damage(float damage)
        {
            value -= damage;
            OnDamage?.Invoke(damage);

            if (value <= 0)
                OnZero?.Invoke();
        }
    }
}