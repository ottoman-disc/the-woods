using OttomanDisc.AI;
using OttomanDisc.StateMachine;
using UnityEngine;

namespace OttomanDisc
{
    public class EntityStateManager : StateManager
    {
        public IMoveIntention moveIntention;

        private void Awake()
        {
            moveIntention = GetComponent<IMoveIntention>();
        }
    }
}
