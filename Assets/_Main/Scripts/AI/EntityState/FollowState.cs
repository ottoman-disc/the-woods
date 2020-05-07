using UnityEngine;

namespace OttomanDisc.AI
{
    public class FollowState : EntityState
    {
        [SerializeField] private Transform target;

        public override void Tick()
        {
            if (Vector3.Distance(t.position, target.position) > 1f)
                moveIntention.Move((target.position - t.position).normalized);
            else 
                moveIntention.Stop();
        }
    }
}
