using UnityEngine;

namespace OttomanDisc
{
    public class SimpleHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] int health = 10;

        public void DamageReceived(IDamage damageValue)
        {
            health -= damageValue.Damage;
        }
    }
}
