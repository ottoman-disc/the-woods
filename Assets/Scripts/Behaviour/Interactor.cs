using UnityEngine;

public class Interactor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D col = collision.collider;

        IInteractable interactable = col.GetComponent<IInteractable>();
        if (interactable != null) interactable.Interact();

        PhotonSharedObject photonSharedObject = col.GetComponent<PhotonSharedObject>();
        if (photonSharedObject != null) photonSharedObject.Take(this.gameObject);
    }
}
