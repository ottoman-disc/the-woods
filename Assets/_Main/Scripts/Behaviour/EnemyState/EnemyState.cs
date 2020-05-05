using UnityEngine;

namespace OttomanDisc.StateMachine
{
    public class EnemyState : State
    {
        protected Transform t;

        protected MotorXZ motor;

        protected override void Awake()
        {
            base.Awake();
            t = this.transform;
        }

        private void Start()
        {
            EnemyStateManager enemyStateManager = stateManager as EnemyStateManager;
            motor = enemyStateManager.motorXZ;
        }
    }
}