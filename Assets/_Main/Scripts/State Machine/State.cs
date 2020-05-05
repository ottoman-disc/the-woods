using UnityEngine;

namespace OttomanDisc.StateMachine
{
    public abstract class State : MonoBehaviour
    {
        protected StateManager stateManager;

        protected virtual void Awake()
        {
            stateManager = GetComponent<StateManager>();

            this.enabled = false;
        }
    }
}
