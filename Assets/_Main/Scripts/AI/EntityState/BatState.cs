using OttomanDisc.StateMachine;
using UnityEngine;

namespace OttomanDisc.AI
{
    public abstract class BatState : State
    {
        protected BatStateManager entityStateManager;

        private void Start() => entityStateManager = stateManager as BatStateManager;

        public virtual void OnSeenPlayer(Transform target) { }
    }
}
