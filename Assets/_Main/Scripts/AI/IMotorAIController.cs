using UnityEngine;

namespace OttomanDisc.AI
{
    public interface IMotorAIController
    {
        void SetTarget(Transform target);

        void SetTargetPosition(Vector3 position);
    }
}