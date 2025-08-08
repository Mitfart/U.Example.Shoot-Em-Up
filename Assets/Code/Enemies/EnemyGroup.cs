using System;
using System.Collections.Generic;
using Battle;
using UnityEngine;

namespace Enemies
{
    public class EnemyGroup : MonoBehaviour
    {
        public event Action<Entity> OnEnemyDispose;
        public event Action OnClear;

        [SerializeField] private List<Entity> enemies;

        public IReadOnlyList<Entity> Enemies => enemies;
        

        
        private void OnEnable() { foreach (var enemy in enemies) enemy.OnDie += ProgressPattern; }
        private void OnDisable() { foreach (var enemy in enemies) enemy.OnDie -= ProgressPattern; }

        
        
        private void ProgressPattern(Entity enemy)
        {
            OnEnemyDispose?.Invoke(enemy);
            enemies.Remove(enemy);

            if (enemies.Count > 0) return;
            
            OnClear?.Invoke();
            Destroy(gameObject);
        }
    }
}