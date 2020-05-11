using OttomanDisc.StateMachine;
using UnityEngine;

namespace OttomanDisc.AI
{
    public class BatStateManager : StateManager
    {
        // States
        private BatState CurrentBatState;

        [SerializeField] private GoHomeState goHomeState;
        [SerializeField] private FollowState followState;
        [SerializeField] private PatrolState patrolState;

        private Transform t;
        public Vector3 startingPosition;

        [SerializeField] private GameObject detectTrigger;

        private IMoveIntention moveIntention;

        private void Awake()
        {
            t = this.transform;
            startingPosition = t.position;
            moveIntention = GetComponent<IMoveIntention>();

            CurrentBatState = CurrentState as BatState;
        }

        // State Behaviours
        public void EntityTrigger(Transform target)
        {
            CurrentBatState.OnSeenPlayer(target);
        }

        public void SetAlert(bool alert)
        {
            detectTrigger.SetActive(alert);
        }

        // Actions
        public void SetTarget(Transform target)
        {
            moveIntention.SetTarget(target);
        }

        public void SetTarget(Vector3 target)
        {
            moveIntention.SetTargetPosition(target);
        }
    }
}
