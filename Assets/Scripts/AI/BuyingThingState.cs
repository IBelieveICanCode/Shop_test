using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StateStuff
{
    public class BuyingThingState : State<CustomerModel>
    {

        public override void EnterState(CustomerModel owner)
        {
            owner.StartCoroutine(BuyThingsCor(owner, 3));
        }

        public override void ExitState(CustomerModel owner)
        {
            
        }

        public override void UpdateState(CustomerModel owner)
        {
            
        }

        IEnumerator BuyThingsCor(CustomerModel owner, float duration)
        {
            float progress = 0;
            while (progress <= 1f)
            {
                progress += Time.deltaTime / duration;
                owner.HUD.FillProgressBar(progress);
                yield return null;
            }
            owner.SignalBus.Fire(new GivePlayerPointsSignal(10));
            owner.HUD.FillProgressBar(0);
            owner.StateMachine.ChangeState(new ReadyForShoppingState());
        }
    }
}
