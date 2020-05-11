namespace OttomanDisc.AI
{
    public class GoHomeState : EntityState
    {
        public override void Enter()
        {
            base.Enter();

            BatTestStateManager batStateManager = entityStateManager as BatTestStateManager;

            moveIntention.SetTargetPosition(batStateManager._home.position);
        }
    }
}
