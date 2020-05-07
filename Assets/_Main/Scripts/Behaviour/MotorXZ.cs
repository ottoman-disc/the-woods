using UnityEngine;

namespace OttomanDisc
{
    [RequireComponent(typeof(Rigidbody))]
    public class MotorXZ : MonoBehaviour
    {
        private Rigidbody _rb;
        private Vector3 _direction;
        private bool moving = false;
        [SerializeField] [Range(0f, 1f)] private float speed = 0.2f;

        private void Awake()
        {
            _rb = this.GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (moving) _rb.velocity = _direction * speed;
        }

        public void Move(Vector3 direction)
        {
            _rb.drag = 0f;
            _direction = direction;
            moving = true;
        }

        public void Stop()
        {
            _rb.drag = 50f;
            moving = false;
        }
    }
}
