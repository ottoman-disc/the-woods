using OttomanDisc.StateMachine;
using UnityEngine;

namespace OttomanDisc.AI
{
    public class EntityStateManager : StateManager
    {
        [Header("ENTITY")]

        [SerializeField] private GameObject detectTrigger;

        [SerializeField] private FollowState followState;

        public void MoveTowards(Transform target)
        {
            GetComponent<IMoveIntention>().SetTarget(target);
        }

        public void Follow(Transform target)
        {
            SetState(followState);
        }

        public void SetAlert(bool alert)
        {
            detectTrigger.SetActive(alert);
        }
    }
}
