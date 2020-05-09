using OttomanDisc.Art;
using OttomanDisc.StateMachine;
using UnityEngine;

namespace OttomanDisc.AI
{
    public class EntityState : State
    {
        protected Transform t;
        protected EntityStateManager entityStateManager;

        protected IMoveIntention moveIntention;

        protected override void Awake()
        {
            base.Awake();
            t = this.transform;

            moveIntention = GetComponent<IMoveIntention>();
        }

        protected override void Start()
        {
            base.Start();

            entityStateManager = stateManager as EntityStateManager;
        }
    }
}
