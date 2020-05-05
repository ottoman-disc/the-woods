namespace OttomanDisc.AI
{
    public class IdleState : EntityState
    {
        protected override void OnEnable()
        {
            base.OnEnable();

            if (moveIntention != null)
                moveIntention.Stop();
        }
    }
}
