using UnityEngine;

namespace OttomanDisc
{
    // This behaviour is, at this point, really just for testing - we don't currently know
    // what 'interacting' is going to look like at this point
    public class Interactor : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Collider2D col = collision.collider;

            IInteractable interactable = col.GetComponent<IInteractable>();
            if (interactable != null) interactable.Interact();
        }
    }
}
