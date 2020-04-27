using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Motor))]
public class PlayerController : MonoBehaviour
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
        moter.Move(context.ReadValue<Vector2>());
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
