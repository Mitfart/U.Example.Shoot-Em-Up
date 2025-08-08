using UnityEngine;

namespace Movement
{
    public class TranslateMove : MoveBehaviour
    {
        public override Vector2 Velocity => MoveDir * speed;
        
        protected override void ProcessMove() => transform.Translate(MoveDir * (speed * Time.deltaTime));
    }
}