using UnityEngine;

namespace OttomanDisc.AI
{
    public class PatrolState : BatState
    {
        [SerializeField] private float frequency = 2f;
        [SerializeField] private float range = 5f;

        private float timer;

        public override void Enter()
        {
            base.Enter();

            SetRandomTarget();
        }

        public override void Tick()
        {
            base.Tick();

            if (Time.time - timer > frequency) SetRandomTarget();
        }

        private void SetRandomTarget()
        {
            Vector3 newPosition;

            if (Vector3.Distance(this.transform.position, entityStateManager.startingPosition) > range)
                newPosition = entityStateManager.startingPosition;
            else
                newPosition = entityStateManager.startingPosition.GetRandomPositionOnCircle(5f);

            entityStateManager.SetTarget(newPosition);

            timer = Time.time;
        }
    }
}
