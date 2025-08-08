using Battle;
using Shooting;
using UnityEngine;

namespace Hero
{
    public class HeroAnimator : MonoBehaviour
    {
        private static readonly int MoveX = Animator.StringToHash("SpeedX");
        private static readonly int Shot = Animator.StringToHash("Shot");
        private static readonly int Invincible = Animator.StringToHash("Invincible");

        public Animator animator;
        public HeroController controller;
        public HurtArea hurtArea;
        
        public GameObject body;
        public float iFrameDuration;

        private float _lastIFrameTime;


        
        private void OnEnable() => controller.shooter.OnShot += TriggerShot;
        private void OnDisable() => controller.shooter.OnShot -= TriggerShot;

        private void Update()
        {
            SetSpeed();
            PlayInvincibleAnim(hurtArea.Invincible);
        }


        private void PlayInvincibleAnim(bool invincible)
        {
            if (invincible)
            {
                if (Time.time - _lastIFrameTime < iFrameDuration) return;

                _lastIFrameTime = Time.time;
            
                body.SetActive(!body.activeSelf);
            }
            else
            {
                body.SetActive(true);
            }
        }


        private void SetSpeed() => animator.SetFloat(MoveX, controller.movement.Velocity.x);
        private void TriggerShot(Bullet _) => animator.SetTrigger(Shot);
    }
}