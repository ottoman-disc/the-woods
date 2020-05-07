using UnityEngine;

namespace OttomanDisc.StateMachine
{
    public abstract class StateManager : MonoBehaviour
    {
        [SerializeField] protected State DefaultState;
        [SerializeField] protected State CurrentState;

        protected virtual void Start()
        {
            SetState(DefaultState);
        }

        protected virtual void Update()
        {
            if (CurrentState == null) SetState(DefaultState);
            else CurrentState.Tick();
        }

        public void SetState(State state)
        {
            if (state == CurrentState) return; // Probably don't want to set the state to our current state.

            if (CurrentState != null) CurrentState.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }
    }
}
