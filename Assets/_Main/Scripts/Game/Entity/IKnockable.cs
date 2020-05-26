using UnityEngine;

namespace OttomanDisc
{
    public interface IKnockable
    {
        void Knockback(Vector3 direction, float power);
    }
}
