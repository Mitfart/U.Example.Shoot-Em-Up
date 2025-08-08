using System;
using UnityEngine;

namespace Score
{
    public class Score : MonoBehaviour
    {
        public event Action<int, int> OnChange;
        
        public int Value { get; private set; }



        public void Add(int v) => OnChange?.Invoke(Value, Value += v);
    }
}