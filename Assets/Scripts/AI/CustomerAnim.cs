using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class CustomerAnim : MonoBehaviour
{
    NavMeshAgent _agent;
    Animator _anim;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_agent.hasPath && _agent.hasPath)
            _anim.SetFloat("speed", _agent.velocity.magnitude);
    }
}
