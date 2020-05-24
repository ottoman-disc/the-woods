using UnityEngine;

namespace OttomanDisc
{
    public class SimpleHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] int health = 10;

        [SerializeField] EffectConfig damageEffect;
        [SerializeField] EffectConfig deathEffect;

        Transform _transform;

        private void Awake()
        {
            _transform = this.transform;
        }

        public void DamageReceived(IDamage damageValue)
        {
            health -= damageValue.Damage;
            damageEffect.Spawn(_transform.position);

            if (health <= 0) Die();
        }

        public void Die()
        {
            deathEffect.Spawn(_transform.position);

            Destroy(this.gameObject);
        }
    }
}
