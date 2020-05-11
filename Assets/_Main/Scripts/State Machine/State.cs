using UnityEngine;

namespace OttomanDisc.StateMachine
{
    public abstract class State : MonoBehaviour
    {
        protected StateManager stateManager;

        protected virtual void Awake() => stateManager = GetComponent<StateManager>();

        public virtual void Enter() { Debug.Log("Entering "); }

        public virtual void Tick() { }

        public virtual void Exit() { }
    }
}
