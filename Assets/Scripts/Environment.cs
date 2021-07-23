using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField]
    Transform[] _startingPositions;
    Queue<Transform> _startingPosQueue;

    private void Awake()
    {
        _startingPosQueue = new Queue<Transform>(_startingPositions);
    }

    public Transform GetStartingPoint()
    {
        Transform startPos = _startingPosQueue.Dequeue();
        _startingPosQueue.Enqueue(startPos);
        return startPos;
    }
}
