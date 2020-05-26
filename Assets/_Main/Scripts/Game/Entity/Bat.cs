using UnityEngine;

namespace OttomanDisc
{
    public class Bat : MonoBehaviour, IKnockable
    {
        public void Knockback(Vector3 knockerPosition, float power)
        {
            this.GetComponent<Motor>().enabled = false;
            Invoke(nameof(KnockbackEnd), .1f);

            this.GetComponent<Rigidbody>().AddForce((this.transform.position - knockerPosition).normalized * power);
        }

        private void KnockbackEnd()
        {
            this.GetComponent<Motor>().enabled = true;
        }
    }
}
