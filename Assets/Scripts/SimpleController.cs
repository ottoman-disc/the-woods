using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D;

public class SimpleController : MonoBehaviour
{
    private PlayerInputActions _inputActions;

    private Transform _transform;
    private Vector2 _direction;

    private void Awake()
    {
        _inputActions = new PlayerInputActions();

        _transform = this.transform;
    }

    private void OnEnable()
    {
        _inputActions.Game.Enable();

        _inputActions.Game.Move.performed += OnMove;
        _inputActions.Game.Move.canceled += OnMove; // We need an event for when you STOP sending a direction, otherwise it won't get reset to (0,0) (eg. letting go of stick)
        _inputActions.Game.Attack.performed += OnAttack;
    }

    private void Update()
    {
        float frameRateScaler = 10 * Time.deltaTime;
        _transform.position += new Vector3(_direction.x, _direction.y, 0) * frameRateScaler;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext _)
    {
        // Setting a random color yay
        Material mat = GetComponent<SpriteShapeRenderer>().material;
        if(mat != null) mat.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    private void OnDisable()
    {
        _inputActions.Game.Attack.performed -= OnAttack;
        _inputActions.Game.Move.canceled -= OnMove;
        _inputActions.Game.Move.performed -= OnMove;

        _inputActions.Game.Disable();
    }
}
