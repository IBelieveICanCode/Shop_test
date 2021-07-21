using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateStuff
{
    public class ReadyForShoppingState : State<CustomerModel>
    {        
        public override void EnterState(CustomerModel owner)
        {
            Debug.Log("Ready For Shopping");
            if (owner.PlacesForBuying.Count <= 0)
                return;
            owner.StateMachine.ChangeState(new GoToShoPlaceState());
        }

        public override void ExitState(CustomerModel owner)
        {

        }

        public override void UpdateState(CustomerModel owner)
        {
           
        }
    }
}
