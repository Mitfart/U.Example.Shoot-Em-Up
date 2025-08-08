using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Viewport))]
    public class AIShootAtTarget : AIShoot {
        public Viewport viewport;
        
        protected override void Shoot_Internal() => shooter.Shoot(viewport.TargetPos);
    }
}