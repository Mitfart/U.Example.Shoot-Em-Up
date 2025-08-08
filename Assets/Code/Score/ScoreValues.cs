using System;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace Score
{
    [CreateAssetMenu(menuName = "SCR/new ScoreValues")]
    public class ScoreValues : ScriptableObject
    {
        [SerializeField] private List<ScoreValue> values;

        private Dictionary<EnemyType, int> _values;

        public int Get(EnemyType enemyType) => _values[enemyType];

        
        
        public void Init()
        {
            _values ??= new Dictionary<EnemyType, int>();
            _values.Clear();
            
            foreach (var v in values) _values[v.enemyType] = v.score;
        }
    }

    [Serializable]
    internal struct ScoreValue
    {
        public EnemyType enemyType;
        public int score;
    }
}