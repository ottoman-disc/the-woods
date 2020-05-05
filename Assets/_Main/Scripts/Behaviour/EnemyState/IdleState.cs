namespace OttomanDisc.StateMachine
{
    public class IdleState : EnemyState
    {
        private void OnEnable()
        {
            if (motor == null) return;
            motor.Stop();
        }
    }
}
