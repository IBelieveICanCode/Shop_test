using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using StateStuff;
using Zenject;

[RequireComponent(typeof(CustomerHUD))]
[RequireComponent(typeof(NavMeshAgent))]
public class CustomerModel : MonoBehaviour
{
    public CustomerHUD HUD { get; private set; }

    public NavMeshAgent Agent { get; private set; }
    public StateMachine<CustomerModel> StateMachine { get; private set; }

    public Vector3 StartingPosition { get; private set; }


    [Inject]
    readonly IForCustomers _myShop;

    [Inject]
    public SignalBus SignalBus { get; private set; }

    public Stack<BuyingPlace> PlacesForBuying { get; private set; }
    public BuyingPlace CurrentPlaceForBuying { get; private set; }


    [Inject]
    public void Construct(Vector3 startingPosition)
    {
        StartingPosition = startingPosition;
    }

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        HUD = GetComponent<CustomerHUD>();

        StateMachine = new StateMachine<CustomerModel>(this);
    }

    private void Start()
    {
        MakeShoppingList();
        StateMachine.ChangeState(new ReadyForShoppingState());
    }

    private void Update() => StateMachine.Update();

    public void MakeShoppingList(int amount = 3)//To DO settings
    {
        int seed = Random.Range(0, int.MaxValue);
        List<BuyingPlace> shuffledBuyingPlaces = new List<BuyingPlace>(
            Utility.ShuffleArray(_myShop.BuyingPlaces, seed));

        PlacesForBuying = new Stack<BuyingPlace>(shuffledBuyingPlaces.Take(amount).ToArray());
    }



    public class CustomerFactory : PlaceholderFactory<Vector3, CustomerModel>
    {
    }
}
