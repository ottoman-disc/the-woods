namespace OttomanDisc.AI
{
    public class IdleState : EntityState
    {
        public override void Enter()
        {
            base.Enter();

            if (moveIntention != null)
                moveIntention.Stop();
        }
    }
}
