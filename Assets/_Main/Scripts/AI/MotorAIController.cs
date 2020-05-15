using UnityEngine;

namespace OttomanDisc.AI
{
    [RequireComponent(typeof(IMotor))]
    public class MotorAIController : MonoBehaviour, IMotorAIController
    {
        private IMotor _motor;
        private Transform _targetTransform;
        private Vector3 _targetPosition;

        private void Awake()
        {
            // this controller will be influencing a motor
            _motor = GetComponent<IMotor>();

            // setting the target position equates to staying in place
            SetTargetPosition(transform.position);
        }

        private void Update()
        {
            Vector3 thisPosition = transform.position;

            if (_targetTransform != null)
            {
                _targetPosition = _targetTransform.position;
            }

            if (Vector3.Distance(thisPosition, _targetPosition) > 0.01f)
                _motor.Move((_targetPosition - thisPosition).normalized);
            else
                _motor.Stop();
        }

        public void SetTargetTransform(Transform target) => _targetTransform = target;

        public void SetTargetPosition(Vector3 position)
        {
            _targetTransform = null;
            _targetPosition = position;
        }
    }

}
