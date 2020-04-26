using UnityEngine;

public class Interactor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IInteractable interactable = collision.collider.GetComponent<IInteractable>();
        if (interactable != null) interactable.Interact();
    }
}
