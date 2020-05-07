using UnityEngine;

namespace OttomanDisc.AI
{
    public interface IMoveIntention
    {
        void Move(Vector3 direction);

        void Stop();
    }

}
