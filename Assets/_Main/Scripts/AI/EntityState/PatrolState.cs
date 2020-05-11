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

            BatTestStateManager batStateManager = entityStateManager as BatTestStateManager;

            center = batStateManager._home.position;

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

            if (Vector3.Distance(t.position, center) > range)
                newPosition = center;
            else
                newPosition = center.GetRandomPositionOnCircle(5f);

            if (moveIntention != null)
                moveIntention.SetTargetPosition(newPosition);

            timer = Time.time;
        }
    }

    public static class Vector3Extension
    {
        public static Vector3 GetRandomPositionOnCircle(this Vector3 center, float range)
        {
            Vector3 randomUnitSphere = Random.insideUnitSphere;
            randomUnitSphere.y = 0f;
            return center + randomUnitSphere * range;
        }
    }
}
