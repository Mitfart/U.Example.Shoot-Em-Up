using Shooting;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Shooter), typeof(Animator))]
    public abstract class AIShoot : MonoBehaviour
    {
        private static readonly int Attacking = Animator.StringToHash("Attacking");

        public Shooter shooter;
        public Animator animator;
        public float attackPeriod;

        private float _lastAttackTime;


        
        private void Update()
        {
            if (Time.time - _lastAttackTime >= attackPeriod)
                animator.SetBool(Attacking, true);
        }

        // EXECUTED BY ANIMATION EVENT 
        private void Shoot_External()
        {
            _lastAttackTime = Time.time;

            Shoot_Internal();
            
            animator.SetBool(Attacking, false);
        }

        protected abstract void Shoot_Internal();
    }
}