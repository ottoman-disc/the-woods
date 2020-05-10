using UnityEngine;

namespace OttomanDisc.AI
{
    public class EntityTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<IEntity>() != null)
                GetComponentInParent<EntityStateManager>().Follow(other.transform);
        }
    }
}
