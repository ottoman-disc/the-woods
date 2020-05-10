using UnityEngine;

namespace OttomanDisc.AI
{
    public class FollowState : EntityState
    {
        private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public override void Tick()
        {
            if (Vector3.Distance(t.position, _target.position) > 1f)
                moveIntention.Move((_target.position - t.position).normalized);
            else 
                moveIntention.Stop();
        }
    }
}
