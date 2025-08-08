using System;
using UnityEngine;

namespace Misc
{
    public class CheckArea : MonoBehaviour
    {
        public event Action<GameObject> OnHit;

        public LayerMask collisionMask;
        public float radius;

        public bool single;

        

        private void FixedUpdate() => CheckHit();

        private void CheckHit()
        {
            if (single)
                CheckSingleHit();
            else
                CheckAllHits();
        }

        
        private void CheckAllHits()
        {
            var hits = Physics2D.OverlapCircleAll(
                transform.position,
                radius,
                collisionMask
            );

            foreach (var hit in hits)
                OnHit?.Invoke(hit.gameObject);
        }

        private void CheckSingleHit()
        {
            var hit = Physics2D.OverlapCircle(
                transform.position,
                radius,
                collisionMask
            );

            if (hit) OnHit?.Invoke(hit.gameObject);
        }


        protected virtual void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}