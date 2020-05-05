using OttomanDisc.StateMachine;
using UnityEngine;

namespace OttomanDisc.AI
{
    public class EntityState : State
    {
        protected Transform t;

        protected MoveIntention moveIntention;

        protected override void Awake()
        {
            base.Awake();
            t = this.transform;

            EntityStateManager enemyStateManager = stateManager as EntityStateManager;
            moveIntention = enemyStateManager.directionIntention;
        }

        protected virtual void OnEnable()
        {
            Debug.Log("<color=blue>[ENTITY STATE]</color> " + this.name +": Entered "+ GetType().Name);
        }
    }
}