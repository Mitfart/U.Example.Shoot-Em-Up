using System;
using UnityEngine;

namespace Shooting
{
    public class ShooterReloading : MonoBehaviour
    {
        public Shooter shooter;
        public float duration;
        
        

        private void OnEnable() => shooter.OnShot += Reload;
        private void OnDisable() => shooter.OnShot -= Reload;

        private async void Reload(Bullet _)
        {
            shooter.Block();

            try
            {
                await Awaitable.WaitForSecondsAsync(duration, destroyCancellationToken);
                
                if (enabled) shooter.Unblock();
            }
            catch (Exception) { /* ignored */ }
        }
    }
}