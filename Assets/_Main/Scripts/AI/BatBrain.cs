using UnityEngine;

namespace OttomanDisc.AI
{
    public enum BatAnimations
    {
        isFlying
    }
    public class BatBrain : MonoBehaviour
    {
        private Vector3 startingPosition;

        public Transform currentTarget;

        private IMotorAIController moveIntention;
        private Animator animator;
        private IMotor motor;
        private bool goingHome = false; // tracks flight home in order to trigger animation

        private void Awake()
        {
            startingPosition = this.transform.position;
            moveIntention = GetComponent<IMotorAIController>();
            animator = GetComponent<Animator>();
            motor = GetComponent<IMotor>();
        }

        private void Update()
        {
            if (!motor.IsMoving && goingHome)
            {
                // bat was retunring home and is now stationary
                goingHome = false;
                SetAnimation(BatAnimations.isFlying, false);
            }
        }

        // Trigger Callbacks
        private void OnTriggerEnter(Collider other)
        {
            if (currentTarget != null) return; // If already has a target, ignore

            if (other.GetComponent<Player>() != null)
            {
                SetAnimation(BatAnimations.isFlying, true);
                SetTarget(other.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform == currentTarget) GoHome();
        }

        // Behaviour
        private void SetTarget(Transform target)
        {
            currentTarget = target;
            moveIntention.SetTargetTransform(target);
        }

        private void SetAnimation(BatAnimations animation, bool value)
        {
            if (animator)
            {
                animator.SetBool(animation.ToString(), value);
            }
        }

        private void GoHome()
        {
            currentTarget = null;
            goingHome = true;
            moveIntention.SetTargetPosition(startingPosition);
        }
    }

}
