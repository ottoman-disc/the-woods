using UnityEngine;

namespace OttomanDisc
{
    public interface IMotor
    {
        void Move(Vector3 direction);
        void Stop();
    }
}