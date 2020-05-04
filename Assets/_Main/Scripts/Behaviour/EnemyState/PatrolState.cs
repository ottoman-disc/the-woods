using OttomanDisc.StateMachine;
using UnityEngine;

namespace OttomanDisc
{
    public class PatrolState : State
    {
        [SerializeField] private MotorXZ motor;
        [SerializeField] private float speed = 0.1f;
        [SerializeField] private float frequency = 2f;

        private float timer;

        private void OnEnable()
        {
            SetRandomDirection();
        }

        private void Update()
        {
            if (Time.time - timer > frequency) SetRandomDirection();
        }

        private void SetRandomDirection()
        {
            Vector3 direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

            motor.Move(direction * speed);

            timer = Time.time;
        }
    }
}
