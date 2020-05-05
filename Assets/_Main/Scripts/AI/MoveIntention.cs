using UnityEngine;

namespace OttomanDisc.AI
{
    public class MoveIntention : MonoBehaviour
    {
        public delegate void MoveAction(Vector3 direction);
        public event MoveAction OnMove;

        public delegate void StopAction();
        public event StopAction OnStop;

        public Vector3 Value;

        [SerializeField] private MotorXZ motor;

        private void OnEnable()
        {
            OnMove += motor.Move;
            OnStop += motor.Stop;
        }

        public void Move(Vector3 direction)
        {
            OnMove.Invoke(direction);
        }

        public void Stop()
        {
            OnStop.Invoke();
        }

        private void OnDisable()
        {
            OnMove -= motor.Move;
            OnStop -= motor.Stop;
        }
    }
}
