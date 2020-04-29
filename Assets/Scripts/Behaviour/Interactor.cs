using UnityEngine;
using Photon.Pun;

public class Interactor : MonoBehaviour
{
    public bool isLocal;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IInteractable interactable = collision.collider.GetComponent<IInteractable>();
        if (interactable != null) interactable.Interact(this.gameObject);
    }
}
