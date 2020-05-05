using UnityEngine;

namespace OttomanDisc.AI
{
    public class IdleState : EnemyState
    {
        private void OnEnable()
        {
            if (directionIntention != null)
                directionIntention.Value = Vector3.zero;

            if (motor == null) return;
            motor.Stop();
        }
    }
}
