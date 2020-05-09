using UnityEngine;

namespace OttomanDisc.AI
{
    public class DetectionZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {

            if (other.GetComponent<MotorXZController>() != null)
                GetComponentInParent<EntityStateManager>().Follow();
        }
    }
}
