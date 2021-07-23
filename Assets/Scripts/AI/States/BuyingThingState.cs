using System.Collections;
using UnityEngine;
using StateStuff;

namespace ShoppingGame.Customer
{
    public class BuyingThingState : State<ConsumerModel>
    {

        public override void EnterState(ConsumerModel owner)
        {
            owner.StartCoroutine(BuyThingsCor(owner, owner.BuyingTime));
        }

        IEnumerator BuyThingsCor(ConsumerModel owner, float duration)
        {
            float progress = 0;
            while (progress <= 1f)
            {
                progress += Time.deltaTime / duration;
                owner.HUD.FillProgressBar(progress);
                yield return null;
            }
            owner.SignalBus.Fire(new GivePlayerCoinsSignal(owner.Scores));
            owner.HUD.FillProgressBar(0);
            owner.StateMachine.ChangeState(new ReadyForShoppingState());
        }

        public override void ExitState(ConsumerModel owner)
        {          
        }

        public override void UpdateState(ConsumerModel owner)
        {          
        }


    }
}
