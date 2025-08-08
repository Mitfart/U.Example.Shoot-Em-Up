using Extensions.Transform;
using UnityEngine;

namespace Movement
{
    public class MoveByDirection : MonoBehaviour
    {
        public MoveBehaviour moveBehaviour;
        public Direction direction = Direction.Up;


        
        private void Update() => moveBehaviour.Move(direction.AsVector());
    }
}