using UnityEngine;

namespace OttomanDisc
{
    public class SphereAttack : MonoBehaviour, IDamage
    {
        [SerializeField] LayerMask layerMask;

        [SerializeField] private float range = 0.5f;

        private Transform _transform;

        public int Damage => 1;

        private bool _isAttacking;
        private Vector3 _direction;

        private void Awake()
        {
            _transform = this.transform;
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        public void OnAttackActivated()
        {
            Collider[] hitColliders = Physics.OverlapSphere(_transform.position + _direction.normalized, range, layerMask, QueryTriggerInteraction.Ignore);

            foreach (Collider col in hitColliders)
            {
                IDamageable damageable = col.GetComponent<IDamageable>();
                if (damageable != null) damageable.DamageReceived(this);

                IKnockable knockable = col.GetComponent<IKnockable>();
                if (knockable != null) knockable.Knockback(_transform.position, 200f);
            }

            _isAttacking = true;
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = _isAttacking ? Color.red : Color.blue;
            Gizmos.DrawWireSphere(this.transform.position + _direction.normalized * 0.4f, range);
        }
#endif

    }
}
