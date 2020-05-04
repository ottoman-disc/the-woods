using UnityEngine;

namespace OttomanDisc.StateMachine
{
    public class AttackState : State
    {
        private Transform t;

        [SerializeField] private MotorXZ motor;
        [SerializeField] private Transform target;
        [SerializeField] private float speed = 0.1f;

        private void Awake()
        {
            t = this.transform;
        }

        private void Update()
        {
           motor.Move((target.position - t.position).normalized * speed);
        }

        private void OnDisable()
        {
            if (motor == null) return;
                
            motor.Stop();
        }
    }
}