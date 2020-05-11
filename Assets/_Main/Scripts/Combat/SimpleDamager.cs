using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OttomanDisc
{
    public class SimpleDamager : MonoBehaviour, IDamage
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
