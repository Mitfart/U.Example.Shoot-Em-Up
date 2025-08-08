using Misc;
using UnityEngine;

namespace Enemies
{
    public class Viewport : CheckArea
    {
        public Vector3 TargetPos { get; private set; }


        
        private void Awake() => single = true;
        private void OnEnable() => OnHit += Target;
        private void OnDisable() => OnHit -= Target;
        
        
        
        private void Target(GameObject obj) => TargetPos = obj.transform.position;

        private void OnValidate() => single = true;
    }
}