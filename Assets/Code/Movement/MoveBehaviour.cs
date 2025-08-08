using UnityEngine;

namespace Movement
{
    public abstract class MoveBehaviour : MonoBehaviour
    {
        public float speed;
        
        public Vector2 MoveDir { get; private set; }
        
        public abstract Vector2 Velocity { get; }
        
        
        
        public void Move(Vector2 moveDir)
        {
            MoveDir = moveDir;
            MoveDir.Normalize();

            ProcessMove();
        }
        
        
        
        protected abstract void ProcessMove();
    }
}