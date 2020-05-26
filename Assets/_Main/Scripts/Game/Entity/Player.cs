using OttomanDisc.Art;
using UnityEngine;

namespace OttomanDisc
{
    public class Player : MonoBehaviour
    {
        private IMotor _motor;

        [SerializeField] private SphereAttack weapon;

        private PlayerAnimatorHandler _animatorHandler;

        private Vector3 _direction;

        private void Awake()
        {
            _motor = GetComponent<IMotor>();
            _animatorHandler = GetComponent<PlayerAnimatorHandler>();
        }

        public void Move(Vector3 direction)
        {
            _direction = direction;

            _motor.Move(_direction);
            _animatorHandler.Move(_direction);
            weapon.SetDirection(_direction);
        }

        public void Stop()
        {
            _direction = Vector3.zero;

            _motor.Stop();
        }

        public void Attack()
        {
             //weapon.Attack();

            _animatorHandler.Attack();
        }
    }
}
