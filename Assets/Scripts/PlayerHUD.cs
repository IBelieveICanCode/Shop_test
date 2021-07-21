using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerHUD : MonoBehaviour
{
    [Inject]
    private readonly SignalBus _signalBus;

    private void Start()
    {
        _signalBus.Subscribe<GivePlayerPointsSignal>(x => CountScores(x.Points));
    }

    void CountScores(int scores)
    {
        Debug.Log(scores);
    }
}
