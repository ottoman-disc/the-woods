using OttomanDisc.AI;
using OttomanDisc.StateMachine;
using UnityEngine;

namespace OttomanDisc
{
    public class EnemyStateManager : StateManager
    {
        [SerializeField] public MotorXZ motorXZ;

        [SerializeField] public MoveIntention directionIntention;
    }
}
