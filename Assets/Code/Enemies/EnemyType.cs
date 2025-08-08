using Battle;
using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(menuName = "SCR/new EnemyType")]
    public class EnemyType : ScriptableObject
    {
        public string title;
        public Entity enemyAsset;
    }
}