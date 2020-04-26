using UnityEngine;

public class Motor : MonoBehaviour
{
    private Vector2 _direction;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //_rb.velocity = _direction * 10;

        _rb.MovePosition(_rb.position + _direction * 10 * Time.fixedDeltaTime);
    }

    public void Move(Vector2 direction)
    {
        _direction = direction;
    }
}
