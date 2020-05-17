using UnityEngine;
using UnityEngine.InputSystem;

namespace OttomanDisc
{
    [RequireComponent(typeof(IMotor))]
    public class MotorInputController : MonoBehaviour
    {
        private PlayerInputActions inputActions;

        private IMotor moter;

        private void Awake()
        {
            inputActions = new PlayerInputActions();

            moter = GetComponent<IMotor>();
        }

        private void OnEnable()
        {
            inputActions.Game.Enable();

            inputActions.Game.Move.performed += OnMove;
            inputActions.Game.Move.canceled += OnMoveStop;
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            var direction2D = context.ReadValue<Vector2>();
            var direction = new Vector3{
                x = direction2D.x,
                y = 0,
                z = direction2D.y
            };
            moter.Move(direction);
        }

        private void OnMoveStop(InputAction.CallbackContext context)
        {
            moter.Stop();
        }

        private void OnDisable()
        {
            inputActions.Game.Move.canceled -= OnMoveStop;
            inputActions.Game.Move.performed -= OnMove;

            inputActions.Game.Disable();
        }
    }
}
