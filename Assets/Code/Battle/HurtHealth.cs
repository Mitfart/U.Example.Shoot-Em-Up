using UnityEngine;

namespace Battle
{
    public class HurtHealth : MonoBehaviour
    {
        public HurtArea hurtArea;
        public Health health;


        private void OnEnable() => hurtArea.OnHurt += health.Damage;
        private void OnDisable() => hurtArea.OnHurt -= health.Damage;
    }
}