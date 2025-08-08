using UnityEngine;

namespace Movement
{
    public class PhysicsMove : MoveBehaviour
    {
        public float acceleration;
        public AnimationCurve accelerationMult;
        public float maxAcceleration;
        public AnimationCurve maxAccelerationMult;
        public Rigidbody2D rb;

        public override Vector2 Velocity => rb.linearVelocity;
        private Vector2 GoalVelocity => MoveDir * speed;


        
        private void FixedUpdate() => ApplyMove();

        protected override void ProcessMove()
        {
            /* PROCESS IN FIXED UPDATE */
        }

        

        private void ApplyMove() => rb.AddForce(RequiredAccel());

        private Vector2 RequiredAccel()
        {
            var velDot = VelDot();

            var accel = (NextVelocity(velDot) - Velocity) / Time.deltaTime;
            accel = Vector2.ClampMagnitude(accel, MaxAcceleration(velDot));

            return accel;
        }

        private float VelDot() => Vector2.Dot(MoveDir, Velocity.normalized);

        private Vector2 NextVelocity(float velDot) =>
            Vector2.MoveTowards(Velocity, GoalVelocity, Acceleration(velDot) * Time.deltaTime);

        private float Acceleration(float velDot) => acceleration * accelerationMult.Evaluate(velDot);
        private float MaxAcceleration(float velDot) => maxAcceleration * maxAccelerationMult.Evaluate(velDot);
    }
}