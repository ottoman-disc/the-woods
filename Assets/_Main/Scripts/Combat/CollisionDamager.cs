using UnityEngine;

namespace OttomanDisc
{
    public class CollisionDamager : MonoBehaviour, IDamage
    {
        public int Damage { get { return 5; } }

        private void OnCollisionEnter(Collision collision)
        {
            IDamageable damageable = collision.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.DamageReceived(this);
            }
        }
    }
}
