using UnityEngine;

namespace OttomanDisc.StateMachine
{
    public class FollowState : EnemyState
    {
        [SerializeField] private Transform target;
        [SerializeField] private float speed = 0.1f;

        private void Update()
        {
            motor.Move((target.position - t.position).normalized * speed);
        }
    }
}
