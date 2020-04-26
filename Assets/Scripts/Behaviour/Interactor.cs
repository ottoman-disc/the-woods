using UnityEngine;

public class Interactor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.GetComponent<IInteractable>()?.Interact();

        this.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 1f, ForceMode2D.Impulse);
    }
}
