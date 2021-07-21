using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "CreateGameConfig")]
public class GameConfig : ScriptableObject
{
    [SerializeField]
    private GameObject _consumerPrefab;
    public GameObject ConsumerPrefab => _consumerPrefab;
}