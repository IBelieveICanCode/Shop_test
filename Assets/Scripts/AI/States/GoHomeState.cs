using UnityEngine;
using StateStuff;

namespace ShoppingGame.Customer
{
    public class GoHomeState : State<ConsumerModel>
    {
        public override void EnterState(ConsumerModel owner)
        {
            owner.Agent.SetDestination(owner.StartingPosition);
        }

        public override void ExitState(ConsumerModel owner)
        {
            owner.MakeNewShoppingList(owner.HowManyGoodsToBuy);
        }

        public override void UpdateState(ConsumerModel owner)
        {
            if (Vector3.Distance(owner.Agent.transform.position, owner.Agent.destination) <= owner.Agent.stoppingDistance)
                owner.StateMachine.ChangeState(new ReadyForShoppingState());
        }
    }
}
