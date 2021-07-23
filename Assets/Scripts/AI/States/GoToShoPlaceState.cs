using UnityEngine;
using StateStuff;

namespace ShoppingGame.Customer
{
    public class GoToShoPlaceState : State<ConsumerModel>
    {
        public override void EnterState(ConsumerModel owner)
        {
            owner.Agent.SetDestination(owner.PlacesForBuying.Pop().PlaceToBuy.position);
        }

        public override void ExitState(ConsumerModel owner)
        {
        }

        public override void UpdateState(ConsumerModel owner)
        {
            if (Vector3.Distance(owner.Agent.transform.position, owner.Agent.destination) <= owner.Agent.stoppingDistance)
                owner.StateMachine.ChangeState(new BuyingThingState());
        }
    }
}
