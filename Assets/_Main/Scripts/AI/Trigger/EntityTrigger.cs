using OttomanDisc.Utility;
using UnityEngine;
using UnityEngine.Events;

namespace OttomanDisc.AI
{
    public class EntityTrigger : MonoBehaviour
    {
        [SerializeField] TransformEvent OnEnterTrigger;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<IEntity>() != null)
            {
                OnEnterTrigger.Invoke(other.transform);
            }
        }
    }
}
