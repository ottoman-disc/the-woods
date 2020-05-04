using UnityEngine;

namespace OttomanDisc.StateMachine
{
    public abstract class State : MonoBehaviour
    {
        protected StateManager stateManager;

        private void Awake()
        {
            this.enabled = false;

            stateManager = GetComponent<StateManager>();
        }
    }
}
