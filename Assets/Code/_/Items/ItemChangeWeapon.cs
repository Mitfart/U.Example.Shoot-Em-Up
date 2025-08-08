using Shooting;
using UnityEngine;
using UnityEngine.Serialization;

namespace @_.Items
{
    public class ItemChangeWeapon : MonoBehaviour
    {
        public Item item;
        [FormerlySerializedAs("projectile")] public Bullet bullet;
        public float duration;


        
        private void OnEnable() => item.OnPickup += PickWeapon;
        private void OnDisable() => item.OnPickup += PickWeapon;

        
        
        private async void PickWeapon(ItemPicker picker)
        {
            /*
            if (!picker.TryGetComponent(out HeroShooter heroShooter)) return;
            
            heroShooter.bonusBullet = bullet;

            await Awaitable.WaitForSecondsAsync(duration);
            
            if (heroShooter.bonusBullet == bullet)
                heroShooter.bonusBullet = null;
            
            */
        }
    }
}