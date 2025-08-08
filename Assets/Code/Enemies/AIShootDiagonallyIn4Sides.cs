using UnityEngine;

namespace Enemies
{
    public class AIShootDiagonallyIn4Sides : AIShoot
    {
        protected override void Shoot_Internal()
        {
            var origin = transform.position;
            shooter.Shoot(origin + new Vector3(1, 1));
            shooter.Shoot(origin + new Vector3(-1, 1));
            shooter.Shoot(origin + new Vector3(1, -1));
            shooter.Shoot(origin + new Vector3(-1, -1));
        }
    }
}