using UnityEngine;

namespace OttomanDisc.AI
{
    public interface IMotorAIController
    {
        void SetTargetTransform(Transform target);

        void SetTargetPosition(Vector3 position);
    }
}