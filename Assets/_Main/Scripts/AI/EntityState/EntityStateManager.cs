using OttomanDisc.StateMachine;
using UnityEngine;

namespace OttomanDisc.AI
{
    public class EntityStateManager : StateManager
    {
        [HideInInspector] public Vector3 startingPoint;

        [SerializeField] private FollowState followState;

        private void Awake()
        {
            startingPoint = this.transform.position;
        }

        public void Follow(Transform target)
        {
            Debug.Log("DETECT");

            followState.SetTarget(target);
            SetState(followState);
        }
    }
}
