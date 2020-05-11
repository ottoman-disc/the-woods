using UnityEngine;

namespace OttomanDisc.AI
{
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
