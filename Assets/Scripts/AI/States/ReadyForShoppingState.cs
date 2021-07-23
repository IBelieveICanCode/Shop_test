using StateStuff;

namespace ShoppingGame.Customer
{
    public class ReadyForShoppingState : State<ConsumerModel>
    {        
        public override void EnterState(ConsumerModel owner)
        {
            if (owner.PlacesForBuying.Count <= 0)
                owner.StateMachine.ChangeState(new GoHomeState());
            else
                owner.StateMachine.ChangeState(new GoToShoPlaceState());
        }

        public override void ExitState(ConsumerModel owner)
        {
        }

        public override void UpdateState(ConsumerModel owner)
        {         
        }
    }
}
