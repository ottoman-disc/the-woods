using UnityEngine;

namespace OttomanDisc.AI
{
    public class PatrolState : EntityState
    {
        [SerializeField] private float frequency = 2f;

        private float timer;

        protected override void OnEnable()
        {
            SetRandomDirection();

            timer = Time.time;
        }

        private void Update()
        {
            if (Time.time - timer > frequency) SetRandomDirection();
        }

        private void SetRandomDirection()
        {
            Vector3 direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

            if (moveIntention != null)
                moveIntention.Move(direction);

            timer = Time.time;
        }
    }
}
