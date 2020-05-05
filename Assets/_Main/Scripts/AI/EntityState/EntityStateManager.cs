using OttomanDisc.AI;
using OttomanDisc.StateMachine;
using UnityEngine;

namespace OttomanDisc
{
    public class EntityStateManager : StateManager
    {
        [SerializeField] public MoveIntention directionIntention;
    }
}
