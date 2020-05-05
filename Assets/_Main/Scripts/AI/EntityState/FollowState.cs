using UnityEngine;

namespace OttomanDisc.AI
{
    public class FollowState : EntityState
    {
        [SerializeField] private Transform target;

        private void Update()
        {
            moveIntention.Move((target.position - t.position).normalized);
        }
    }
}
