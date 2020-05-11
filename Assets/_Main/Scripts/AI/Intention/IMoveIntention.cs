using UnityEngine;

namespace OttomanDisc.AI
{
    public interface IMoveIntention
    {
        void Move(Vector3 direction);

        void Stop();

        void SetTarget(Transform transform);

        void SetTargetPosition(Vector3 position);
    }
}
