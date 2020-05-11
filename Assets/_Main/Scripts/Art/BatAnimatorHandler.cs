using UnityEngine;

namespace OttomanDisc.Art
{
    public class BatAnimatorHandler : AnimatorHandler
    {
        private static readonly int FlyingParameter = Animator.StringToHash("isFlying");

        private IMotor motor;

        protected override void Awake()
        {
            base.Awake();

            motor = GetComponentInParent<IMotor>();
        }

        private void Update()
        {
            if (motor.IsMoving) TakeOff();
            else Settle();
        }

        public void Settle() => animator.SetBool(FlyingParameter, false);

        public void TakeOff() => animator.SetBool(FlyingParameter, true);
    }
}
