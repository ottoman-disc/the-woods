using UnityEngine;

namespace OttomanDisc.StateMachine
{
    public abstract class StateManager : MonoBehaviour
    {
        [SerializeField] protected State DefaultState;
        [SerializeField] protected State CurrentState;

        protected virtual void Start()
        {
            DisableAllStates(); // No states should be active to begin with

            SetState(DefaultState);
        }

        protected virtual void Update()
        {
           if (CurrentState == null) SetState(DefaultState);
        }

        public void SetState(State state)
        {
            if (state == CurrentState) return; // Probably don't want to set the state to our current state.

            if (CurrentState != null) CurrentState.enabled = false;
            CurrentState = state;
            CurrentState.enabled = true;
        }

        private void DisableAllStates()
        {
            State[] AllStates = GetComponents<State>();
            foreach (State state in AllStates) state.enabled = false;
        }
    }
}
