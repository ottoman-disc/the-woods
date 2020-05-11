using UnityEngine;

namespace OttomanDisc.AI
{
    public class FollowState : BatState
    {
        private Transform _target;

        public override void Enter()
        {
            base.Enter();

            entityStateManager.SetAlert(false);

            entityStateManager.EntityTrigger(_target);
        }

        public override void Exit()
        {
            base.Exit();

            entityStateManager.SetAlert(true);

            //entityStateManager.SetState();
        }
    }
}
