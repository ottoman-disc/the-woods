using OttomanDisc.StateMachine;
using UnityEngine;

namespace OttomanDisc.AI
{
    public class EntityState : State
    {
        protected Transform t;

        protected IMoveIntention moveIntention;

        protected override void Awake()
        {
            base.Awake();
            t = this.transform;

            moveIntention = GetComponent<IMoveIntention>();
        }
    }
}
