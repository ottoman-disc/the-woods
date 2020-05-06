using UnityEngine;

namespace OttomanDisc.StateMachine
{
    public abstract class State : MonoBehaviour
    {
        protected StateManager stateManager;

        private const bool log = false;

        protected virtual void Awake()
        {
            LogMethod(nameof(Awake));

            stateManager = GetComponent<StateManager>();
        }

        protected virtual void Start() => LogMethod(nameof(Start));

        public virtual void Enter() => LogMethod(nameof(Enter));

        public virtual void Tick() => LogMethod(nameof(Tick));

        public virtual void Exit() => LogMethod(nameof(Exit));

        private void LogMethod(string method)
        {
            if (log) Debug.Log("<color=blue>[ENTITY STATE]</color> " + GetType().Name + " " + method);
        }
    }
}
