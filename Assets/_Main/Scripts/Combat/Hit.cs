using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OttomanDisc
{
    public class Hit : MonoBehaviour, IDamage
    {
        [SerializeField] LayerMask layerMask;

        [SerializeField] private float range = 0.5f;

        private Transform _thisTransform;

        public int Damage => 1;

        private void Awake()
        {
            _thisTransform = this.transform;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) Attack();
        }

        public void Attack()
        {
            Collider[] hitColliders = Physics.OverlapSphere(_thisTransform.position, range, layerMask, QueryTriggerInteraction.Ignore);

            foreach (Collider col in hitColliders)
            {
                IDamageable damageable = col.GetComponent<IDamageable>();
                if (damageable != null) damageable.DamageReceived(this);
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (Input.GetKey(KeyCode.Space))
                Gizmos.color = Color.red;
            else
                Gizmos.color = Color.blue;
          
            Gizmos.DrawWireSphere(this.transform.position, range);
        }
#endif

    }
}

