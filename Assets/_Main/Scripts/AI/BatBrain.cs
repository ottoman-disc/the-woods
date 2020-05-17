using OttomanDisc.Art;
using UnityEngine;

namespace OttomanDisc.AI
{
    public class BatBrain : MonoBehaviour
    {
        private Vector3 _homePosition;

        private Transform _currentTarget;
        private bool _goingHome = false; // tracks flight home in order to trigger animation

        private IMotorAIController _motorAIController;
        private IMotor _motor;

        private BatAnimatorHandler _animatorHandler;

        private void Awake()
        {
            _homePosition = this.transform.position;

            _motorAIController = GetComponent<IMotorAIController>();
            _motor = GetComponent<IMotor>();

            _animatorHandler = GetComponent<BatAnimatorHandler>();
        }

        private void Update()
        {
            if (!_motor.IsMoving && _goingHome)
            {
                // bat was returning home and is now stationary
                _animatorHandler.Land();
                _goingHome = false;
            }
        }

        // Trigger Callbacks
        private void OnTriggerEnter(Collider other)
        {
            if (_currentTarget != null) return; // If already has a target, ignore

            if (other.GetComponent<Player>() != null)
            {
                SetTarget(other.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform == _currentTarget) GoHome();
        }

        // Behaviour
        private void SetTarget(Transform target)
        {
            _currentTarget = target;
            _motorAIController.SetTargetTransform(target);
            _animatorHandler.TakeOff();
        }

        private void GoHome()
        {
            _currentTarget = null;
            _goingHome = true;
            _motorAIController.SetTargetPosition(_homePosition);
        }
    }

}
