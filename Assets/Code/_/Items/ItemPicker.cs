using Extensions;
using Misc;
using UnityEngine;
using UnityEngine.Serialization;

namespace @_.Items
{
    public class ItemPicker : MonoBehaviour
    {
        [FormerlySerializedAs("pickBox")] public CheckArea pickArea;
        [Min(Consts.EPSILON)] public float hardPickRadius = Consts.EPSILON;
        [Min(Consts.EPSILON)] public float pickSpeed = Consts.EPSILON;


        
        private void OnEnable() => pickArea.OnHit += PickUpItem;

        private void PickUpItem(GameObject obj)
        {
            if (obj.TryGetComponent(out Item item))
                item.PickUp(this);
        }

        

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, hardPickRadius);
        }
    }
}