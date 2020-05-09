using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OttomanDisc.AI
{
    public class GoHomeState : EntityState
    {
        [SerializeField] Transform home;
        Vector3 homePos;

        public override void Enter()
        {
            base.Enter();

           // homePos = home.position;
            // OR

            homePos = entityStateManager.startingPoint;
            HeadHome();
        }

        public override void Tick()
        {
            base.Tick();

            if (Vector3.Distance(t.position, homePos) <= 0.01f)
                moveIntention.Stop();
        }

        private void HeadHome()
        {
            moveIntention.Move((homePos - t.position).normalized);
        }
    }
}
