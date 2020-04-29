using UnityEngine;
using UnityEngine.U2D;

namespace OttomanDisc
{
    public class Tree : MonoBehaviour, IInteractable, IDamage
    {
        public int Damage { get; } = 5;

        public void Interact()
        {
            Material mat = GetComponent<SpriteShapeRenderer>().material;
            if (mat != null) mat.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        private void OnCollisionEnter2D(Collision2D collision )
        {
            IDamageable damageable = collision.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.DamageReceived(this);
            }
                    IInteractable interactable = collision.collider.GetComponent<IInteractable>();
        if (interactable != null) interactable.Interact();
        }
    }
}
