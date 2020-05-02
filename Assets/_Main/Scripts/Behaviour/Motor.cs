using UnityEngine;

namespace OttomanDisc
{
    [RequireComponent(typeof(Rigidbody))]
    public class Motor : MonoBehaviour
    {
        private Rigidbody _rb;
        private Vector3 _direction;
        private bool moving = false;
        private const int speed = 2;

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
