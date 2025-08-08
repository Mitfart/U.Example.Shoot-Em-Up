using Unity.VisualScripting;
using UnityEngine;

namespace Environment
{
    public class UIBackgroundScroll : MonoBehaviour
    {
        public UIBackground background;
        public Vector2 speed;
        

        
        private void Update() => Scroll();

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying
                && enabled
                && !background.IsUnityNull())
                Scroll();
        }

        
        private void Scroll() => background.Move(speed);
    }
}