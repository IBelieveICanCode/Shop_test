using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, IForCustomers
{
    [SerializeField]
    BuyingPlace[] _buyingPositions;
    //Queue<BuyingPlace> _shuffledBuyingPlaces;
    public BuyingPlace[] BuyingPlaces => _buyingPositions;
   
}

[System.Serializable]
public class BuyingPlace
{
    [SerializeField]
    string _name;
    [SerializeField]
    private Transform _spotToBuy;
    public Transform PlaceToBuy => _spotToBuy;
}


