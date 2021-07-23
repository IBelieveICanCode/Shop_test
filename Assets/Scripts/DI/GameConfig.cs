using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "CreateGameConfig")]
public class GameConfig : ScriptableObject
{
    [SerializeField]
    private GameObject _consumerPrefab;
    public GameObject ConsumerPrefab => _consumerPrefab;

    [SerializeField]
    private ConsumerSettings _consumerSettings;
    public ConsumerSettings ConsumerSettings => _consumerSettings;
}


[System.Serializable]
public class ConsumerSettings
{

    [Range(2, 10)]
    [SerializeField]
    private float _speed = 5;
    [Range(2, 10)]
    [SerializeField]
    private float _buyingTime = 3;
    [SerializeField]
    int _howManyGoodsToBuy = 3;
    [SerializeField]
    int _scoresForBuying = 10;

    public float Speed => _speed;
    public float BuyingTime => _buyingTime;
    public int HowManyGoodsToBuy => _howManyGoodsToBuy;
    public int ScoresForBuying => _scoresForBuying;
}