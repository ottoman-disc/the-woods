using UnityEngine;

namespace OttomanDisc.AI
{
    public class FollowEntityTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<IEntity>() != null)
                GetComponentInParent<EntityStateManager>().MoveTowards(other.transform);
        }
    }
}
