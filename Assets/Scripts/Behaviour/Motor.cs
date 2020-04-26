using UnityEngine;
using System.Collections;

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
        _rb.velocity = _direction * 10;
    }

    public void Move(Vector2 direction)
    {
        _direction = direction;
    }
}
