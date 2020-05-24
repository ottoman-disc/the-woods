using UnityEngine;

namespace OttomanDisc.Art
{
    public class BatAnimatorHandler : AnimatorHandler
    {
        private static readonly int FlyingParameter = Animator.StringToHash("isFlying");

        protected override void Awake()
        {
            base.Awake();
        }

        public void Land() => animator.SetBool(FlyingParameter, false);

        public void TakeOff() => animator.SetBool(FlyingParameter, true);
    }
}
