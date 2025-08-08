using System;
using System.Threading.Tasks;
using UnityEngine;

namespace @_.Items
{
    [RequireComponent(typeof(Collider2D))]
    public class Item : MonoBehaviour
    {
        public event Action<ItemPicker> OnPickup;

        public Collider2D pickZone;
        public float fallSpeed;

        private bool _picked;


        
        private void Update() => Fall();


        
        public async void PickUp(ItemPicker picker)
        {
            if (_picked)
                return;

            _picked = true;
            pickZone.enabled = false;

            await MoveToPickUp(picker);
            
            OnPickup?.Invoke(picker);
            
            Destroy(gameObject);
        }

        
        
        private void Fall()
        {
            if (!_picked) transform.Translate(Vector3.down * (fallSpeed * Time.deltaTime));
        }

        private async Task MoveToPickUp(ItemPicker picker)
        {
            while (Vector2.Distance(transform.position, picker.transform.position) > HardPickRadius(picker))
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    picker.transform.position, 
                    picker.pickSpeed * Time.deltaTime
                );
                
                await Awaitable.EndOfFrameAsync();
            } 
        }

        private static float HardPickRadius(ItemPicker picker) => picker.hardPickRadius + Time.deltaTime;
    }
}