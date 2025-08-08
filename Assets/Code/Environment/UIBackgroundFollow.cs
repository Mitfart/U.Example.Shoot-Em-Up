using Unity.VisualScripting;
using UnityEngine;

namespace Environment
{
    public class UIBackgroundFollow : MonoBehaviour
    {
        public UIBackground background;
        public Transform followObject;
        public float followFactor;

        private Vector3 _origin;


        
        private void Start() => _origin = followObject.position;

        private void Update() => Follow();

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying 
                && enabled
                && !background.IsUnityNull()
                && !followObject.IsUnityNull())
                Follow();
        }

        
        private void Follow() => background.Move(TargetPos() - background.Position);

        private Vector3 TargetPos() => Vector3.Lerp(Vector3.zero, followObject.position - _origin, followFactor);
    }
}