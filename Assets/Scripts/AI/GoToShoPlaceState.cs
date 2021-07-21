using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateStuff
{
    public class GoToShoPlaceState : State<CustomerModel>
    {
        public override void EnterState(CustomerModel owner)
        {
            Debug.Log("Go to place");
            owner.Agent.SetDestination(owner.PlacesForBuying.Pop().PlaceToBuy.position);
        }

        public override void ExitState(CustomerModel owner)
        {
        }

        public override void UpdateState(CustomerModel owner)
        {
            if (Vector3.Distance(owner.Agent.transform.position, owner.Agent.destination) <= owner.Agent.stoppingDistance)
                owner.StateMachine.ChangeState(new BuyingThingState());


        }
    }
}
