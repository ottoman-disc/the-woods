using OttomanDisc.Utility;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace OttomanDisc
{
    [RequireComponent(typeof(IMotor))]
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerInputActions inputActions;

        [SerializeField] private Vector3Event Move;
        [SerializeField] private UnityEvent Stop;
        [SerializeField] private UnityEvent Attack;

        private void Awake()
        {
            inputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            inputActions.Game.Enable();

            inputActions.Game.Move.performed += OnMove;
            inputActions.Game.Move.canceled += OnMoveStop;

            inputActions.Game.Attack.performed += OnAttack;
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            var direction2D = context.ReadValue<Vector2>();
            var direction = new Vector3{
                x = direction2D.x,
                y = 0,
                z = direction2D.y
            };
            Move.Invoke(direction);
        }

        private void OnMoveStop(InputAction.CallbackContext context)
        {
            Stop.Invoke();
        }

        private void OnAttack(InputAction.CallbackContext context)
        {
            Attack.Invoke();
        }

        private void OnDisable()
        {
            inputActions.Game.Attack.performed -= OnAttack;

            inputActions.Game.Move.canceled -= OnMoveStop;
            inputActions.Game.Move.performed -= OnMove;

            inputActions.Game.Disable();
        }
    }
}
