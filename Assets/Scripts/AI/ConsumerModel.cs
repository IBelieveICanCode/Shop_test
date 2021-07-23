using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using StateStuff;
using Zenject;

namespace ShoppingGame.Customer
{

    [RequireComponent(typeof(NavMeshAgent), typeof(CustomerHUD))]
    public class ConsumerModel : MonoBehaviour
    {
        public CustomerHUD HUD { get; private set; }

        public NavMeshAgent Agent { get; private set; }
        public StateMachine<ConsumerModel> StateMachine { get; private set; }

        #region Settings
        public float Speed { get; private set; }
        public float BuyingTime { get; private set; }
        public int HowManyGoodsToBuy { get; private set; }
        public int Scores { get; private set; }
        #endregion
        public Vector3 StartingPosition { get; private set; }


        [Inject]
        public SignalBus SignalBus { get; private set; }

        #region ShopRelatedFields
        [Inject]
        readonly IForCustomers _myShop;
        public Stack<BuyingPlace> PlacesForBuying { get; private set; }
        public BuyingPlace CurrentPlaceForBuying { get; private set; }
        #endregion

        [Inject]
        public void Construct(Vector3 startingPosition, ConsumerSettings settings)
        {
            StartingPosition = startingPosition;
            Speed = settings.Speed;
            HowManyGoodsToBuy = settings.HowManyGoodsToBuy;
            BuyingTime = settings.BuyingTime;
            Scores = settings.ScoresForBuying;
        }

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            HUD = GetComponent<CustomerHUD>();
            StateMachine = new StateMachine<ConsumerModel>(this);
        }

        private void Start()
        {
            Agent.Warp(StartingPosition);
            Agent.speed = Speed;
            MakeNewShoppingList(HowManyGoodsToBuy);
            StateMachine.ChangeState(new ReadyForShoppingState());
        }

        private void Update() => StateMachine.Update();

        public void MakeNewShoppingList(int amount)//To DO settings
        {
            int seed = Random.Range(0, int.MaxValue);
            List<BuyingPlace> shuffledBuyingPlaces = new List<BuyingPlace>(
                Utility.ShuffleArray(_myShop.BuyingPlaces, seed));
            PlacesForBuying = new Stack<BuyingPlace>(shuffledBuyingPlaces.Take(amount).ToArray());
        }



        public class CustomerFactory : PlaceholderFactory<Vector3, ConsumerSettings, ConsumerModel>
        {
        }
    }
}
