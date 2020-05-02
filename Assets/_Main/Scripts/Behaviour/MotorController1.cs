using UnityEngine;
using UnityEngine.InputSystem;

namespace OttomanDisc
{
    [RequireComponent(typeof(Motor))]
    public class MotorController1 : MonoBehaviour
    {
        private PlayerInputActions inputActions;

        private Motor moter;

        private void Awake()
        {
            inputActions = new PlayerInputActions();

            moter = GetComponent<Motor>();
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
            Debug.LogFormat("Moving {0}", direction);
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
