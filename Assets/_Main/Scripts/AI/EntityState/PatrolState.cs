using UnityEngine;

namespace OttomanDisc.AI
{
    public class PatrolState : EntityState
    {
        [SerializeField] private float frequency = 2f;
        [SerializeField] private float range = 5f;

        private Vector3 center;

        private float timer;

        public override void Enter()
        {
            base.Enter();

            center = t.position;

            SetRandomDirection();
        }

        public override void Tick()
        {
            base.Tick();

            if (Time.time - timer > frequency) SetRandomDirection();
        }

        private void SetRandomDirection()
        {
            Vector3 direction;

            if (Vector3.Distance(t.position, center) > range)
                direction = (center - t.position).normalized;
            else
                direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

            if (moveIntention != null)
                moveIntention.Move(direction);

            timer = Time.time;
        }
    }
}
