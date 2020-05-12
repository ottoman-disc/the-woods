using UnityEngine;

namespace OttomanDisc.AI
{
    public class MotorAIController : MonoBehaviour, IMotorAIController
    {
        [SerializeField] GameObject motorObject;

        private IMotor _motor;
        private Transform _motorTransform;

        private Transform _targetTransform;
        private Vector3 _targetPosition;

        private void Awake()
        {
            if(motorObject == null)
            {
                Debug.Log("Motor object has not been assigned. Automatically assigning parent. This might not be intended!", this.gameObject);
                motorObject = transform.parent.gameObject;
            }

            _motor = motorObject.GetComponent<IMotor>();
            _motorTransform = motorObject.transform;

            SetTargetPosition(_motorTransform.position); // Target set to our current position to start with. 
        }

        private void Update()
        {
            Vector3 thisPosition = _motorTransform.position;

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
