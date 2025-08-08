using Battle;
using Misc;
using UnityEngine;

namespace Enemies
{
    public class EnemyPlayEffectOnDefeat : MonoBehaviour
    {
        public Entity enemy;
        public LifeSpan effectAsset;


        
        public void OnEnable() => enemy.OnDie += PlayEffect;
        private void OnDisable() => enemy.OnDie -= PlayEffect;


        private void PlayEffect(Entity e)
        {
            Instantiate(effectAsset, e.transform.position, Quaternion.identity);
        }
    }
}