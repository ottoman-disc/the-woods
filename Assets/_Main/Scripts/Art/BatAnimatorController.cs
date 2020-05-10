using UnityEngine;

namespace OttomanDisc.Art
{
    public class BatAnimatorController : EntityAnimatorController
    {
        private Animator animator;

        private const string FlyingParameterString = "isFlying";
        private static int FlyingParameter;

        private IMotor motor;

        private void Awake()
        {
            animator = this.GetComponent<Animator>();

            FlyingParameter = Animator.StringToHash(FlyingParameterString);

            motor = GetComponentInParent<IMotor>();
        }

        private void Update()
        {
            if (motor.IsMoving) TakeOff();
            else Settle();
        }

        private void Settle()
        {
            animator.SetBool(FlyingParameter, false);
        }

        public void TakeOff()
        {
            animator.SetBool(FlyingParameter, true);
        }
    }

    public class EntityAnimatorController : MonoBehaviour
    {

    }
}
