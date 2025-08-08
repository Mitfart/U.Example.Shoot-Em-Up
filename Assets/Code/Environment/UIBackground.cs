using Infrastructure;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Environment
{
    public class UIBackground : MonoBehaviour
    {
        public Render render;
        public RawImage img;
        public Vector2 tileSize;

        private Vector2 _velocity;
        
        public Vector3 Position => img.uvRect.position;

        

        private void LateUpdate()
        {
            RefreshView();
            
            _velocity = Vector2.zero;
        }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying
                && enabled
                && !render.IsUnityNull()
                && !render.mainCamera.IsUnityNull()
                && !img.IsUnityNull())
                LateUpdate();
        }
        
        
        private void RefreshView()
        {
            var cam = render.mainCamera;
            var orthographicSize = cam.orthographicSize;
            
            img.uvRect = new Rect(
                Tiled(img.uvRect.position + _velocity * Time.deltaTime),
                new Vector2(cam.aspect * orthographicSize, orthographicSize * 2f) / tileSize
            );
        }

        public void Move(Vector2 v) => _velocity += v;

        
        private Vector2 Tiled(Vector2 pos)
        {
            return new Vector2(
                pos.x % tileSize.x,
                pos.y % tileSize.y
            );
        }
    }
}