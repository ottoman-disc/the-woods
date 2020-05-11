using UnityEngine;

namespace OttomanDisc.AI
{
    public class MotorMoveIntention : MonoBehaviour, IMoveIntention
    {
        [SerializeField] MotorXZ motor;

        private Transform _target;
        private Vector3 _targetPos;

        private void Awake()
        {
            _targetPos = this.transform.position;
        }

        private void Update()
        {
            if (_target != null)
            {
                _targetPos = _target.position;
            }

            if (Vector3.Distance(motor.transform.position, _targetPos) > 0.01f)
                Move((_targetPos - motor.transform.position).normalized);
            else
                Stop();
        }

        public void Move(Vector3 direction) => motor.Move(direction);

        public void Stop() => motor.Stop();

        public void SetTarget(Transform target) => _target = target;

        public void SetTargetPosition(Vector3 position)
        {
            _target = null;
            _targetPos = position;
        }
    }
}
