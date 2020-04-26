using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions _inputActions;

    private Motor _moter;

    private void Awake()
    {
        _inputActions = new PlayerInputActions();

        _moter = GetComponent<Motor>();
    }

    private void OnEnable()
    {
        _inputActions.Game.Enable();

        _inputActions.Game.Move.performed += OnMove;
        _inputActions.Game.Move.canceled += OnMove;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _moter.Move(context.ReadValue<Vector2>());
    }

    private void OnDisable()
    {
        _inputActions.Game.Move.canceled -= OnMove;
        _inputActions.Game.Move.performed -= OnMove;

        _inputActions.Game.Disable();
    }
}
