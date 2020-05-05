using OttomanDisc.StateMachine;
using UnityEngine;

namespace OttomanDisc.AI
{
    public class EnemyState : State
    {
        protected Transform t;

        protected MotorXZ motor;

        protected MoveIntention directionIntention;

        protected override void Awake()
        {
            base.Awake();
            t = this.transform;
        }

        private void Start()
        {
            EnemyStateManager enemyStateManager = stateManager as EnemyStateManager;
            motor = enemyStateManager.motorXZ;
            directionIntention = enemyStateManager.directionIntention;
        }
    }
}