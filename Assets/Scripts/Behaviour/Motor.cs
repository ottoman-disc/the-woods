using UnityEngine;

public class Motor : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _direction;
    private bool moving = false;

    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       if(moving) _rb.velocity = _direction * 10;
    }

    public void Move(Vector2 direction)
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
