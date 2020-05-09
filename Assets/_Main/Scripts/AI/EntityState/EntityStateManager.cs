using OttomanDisc.StateMachine;
using UnityEngine;

namespace OttomanDisc.AI
{
    public class EntityStateManager : StateManager
    {
        [HideInInspector] public Vector3 startingPoint;

        [SerializeField] private EntityState followState;

        private void Awake()
        {
            startingPoint = this.transform.position;
        }

        public void Follow()
        {
            Debug.Log("DETECT");

            SetState(followState);
        }
    }
}
