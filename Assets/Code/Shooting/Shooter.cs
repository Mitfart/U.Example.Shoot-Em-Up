using System;
using Extensions.Transform;
using Misc;
using UnityEngine;

namespace Shooting
{
    public class Shooter : Spawner<Bullet>
    {
        protected override string ContainerTag => $"[ PROJECTILES | {bulletAsset.name} ]";

        public event Action<Bullet> OnShot;

        public Bullet bulletAsset;
        public Vector2 shootOffset;
        
        public LayerMask collisionMask;
        public float baseDamage = 1f;
        public float damageMult = 1f;
        
        public bool Blocked { get; private set; }
        
        

        public void Shoot(Vector2 at)
        {
            if (Blocked) return;

            var projectile = Spawn(bulletAsset, transform.Position2D() + shootOffset);

            projectile.Init(collisionMask, baseDamage * damageMult);
            projectile.transform.Rotate2D(at, faceTop: true);

            OnShot?.Invoke(projectile);
        }

        public void Block() => Blocked = true;
        public void Unblock() => Blocked = false;
    }
}