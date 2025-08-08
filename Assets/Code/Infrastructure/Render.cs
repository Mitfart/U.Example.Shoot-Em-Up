using UnityEngine;

namespace Infrastructure
{
    public class Render : MonoBehaviour
    {
        public Camera mainCamera;

        public Vector2 Boundaries { get; private set; }

        public Vector2 CameraPos => mainCamera.transform.position;


    
        private void Awake() => InitBoundaries();

        private void InitBoundaries()
        {
            Boundaries = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        }
    }
}