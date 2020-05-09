using UnityEngine;

namespace OttomanDisc
{
    public interface IMotor
    {
        bool IsMoving { get; }

        void Move(Vector3 direction);
        void Stop();
    }
}