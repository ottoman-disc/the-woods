using UnityEngine;
using UnityEngine.InputSystem;

// For testing only! Probably.
public class ClickBomb : MonoBehaviour
{
    private PlayerInputActions inputActions;

    private Vector2 mousePos;

    private Camera cam;

    private void Awake()
    {
        inputActions = new PlayerInputActions();

        cam = Camera.main;
    }

    private void OnEnable()
    {
        inputActions.Debug.Enable();

        inputActions.Debug.MoveMouse.performed += OnMoveMouse;
        inputActions.Debug.Bomb.performed += OnBomb;
    }

    private void OnMoveMouse(InputAction.CallbackContext context)
    {
        mousePos = context.ReadValue<Vector2>();
    }

    private void OnBomb(InputAction.CallbackContext context)
    {
        Explode(cam.ScreenToWorldPoint(mousePos));
    }

    private void Explode(Vector3 pos)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, 100f);
        foreach (Collider2D col in colliders)
        {
            col.attachedRigidbody.AddForce((col.transform.position - pos).normalized * 1000f);
        }
    }

    private void OnDisable()
    {
        inputActions.Debug.Disable();

        inputActions.Debug.Bomb.performed -= OnBomb;
        inputActions.Debug.MoveMouse.performed -= OnMoveMouse;
    }
}
