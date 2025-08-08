using Infrastructure;
using UnityEngine;

namespace Hero
{
    public class ScreenBounded : MonoBehaviour
    {
        public Render render;
        public Vector2 offset;
        
        
        
        private void LateUpdate() => ClampPosition();

        
        
        private void ClampPosition()
        {
            var pos = transform.position;
            var cameraPos = render.CameraPos;
            var boundaries = render.Boundaries - offset;
            
            pos.x = Mathf.Clamp(pos.x, -boundaries.x + cameraPos.x, boundaries.x + cameraPos.x);
            pos.y = Mathf.Clamp(pos.y, -boundaries.y + cameraPos.y, boundaries.y + cameraPos.y);
            
            transform.position = pos;
        }
    }
}