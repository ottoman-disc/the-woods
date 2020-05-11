namespace OttomanDisc.AI
{
    public class GoHomeState : BatState
    {
        public override void Enter()
        {
            base.Enter();

            entityStateManager.SetTarget(entityStateManager.startingPosition);
        }
    }
}
