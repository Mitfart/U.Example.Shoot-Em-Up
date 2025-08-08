using Movement;
using Shooting;
using UnityEngine;

namespace Hero
{
    public class HeroController : MonoBehaviour
    {
        public PhysicsMove movement;
        public Shooter shooter;

        private Controls _controls;


        
        private void Awake() => _controls = new Controls();
        private void OnEnable() => _controls.Enable();
        private void OnDisable() => _controls.Disable();

        private void Update()
        {
            movement.Move(_controls.Player.Move.ReadValue<Vector2>());
            
            if (_controls.Player.Attack.IsPressed()) 
                shooter.Shoot(transform.position + Vector3.up);
        }
    }
}


