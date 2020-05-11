using UnityEngine;

namespace OttomanDisc.AI
{
    public class MotorAIController : MonoBehaviour, IMotorAIController
    {
        [SerializeField] GameObject motorObject;
        IMotor motor;

        private Transform t;

        private Transform _targetTransform;
        private Vector3 _targetPosition;

        private void Awake()
        {
            if(motorObject == null)
            {
                Debug.Log("motor Object has not been assigned. Automatically assigning parent. This may not be correct!", this.gameObject);
                motorObject = transform.parent.gameObject;
            }

            motor = motorObject.GetComponent<IMotor>();
            t = motorObject.transform;

            _targetPosition = this.transform.position;
        }

        private void Update()
        {
            if (_targetTransform != null)
            {
                _targetPosition = _targetTransform.position;
            }

            if (Vector3.Distance(t.position, _targetPosition) > 0.01f)
                Move((_targetPosition - t.position).normalized);
            else
                Stop();
        }

        public void Move(Vector3 direction) => motor.Move(direction);

        public void Stop() => motor.Stop();

        public void SetTarget(Transform target) => _targetTransform = target;

        public void SetTargetPosition(Vector3 position)
        {
            _targetTransform = null;
            _targetPosition = position;
        }
    }

}
