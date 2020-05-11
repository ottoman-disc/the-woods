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

        public override void Enter()
        {
            base.Enter();

            entityStateManager.SetAlert(false);

            moveIntention.SetTarget(_target);
        }

        public override void Exit()
        {
            base.Exit();

            entityStateManager.SetAlert(true);

            moveIntention.Stop();
        }
    }
}
