using UnityEngine;
using UnityEngine.AI;

namespace ShoppingGame.Customer
{
    [RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
    public class ConsumerAnim : MonoBehaviour
    {
        NavMeshAgent _agent;
        Animator _anim;

        const string SPEED_PARAM = "speed";

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _anim = GetComponent<Animator>();
        }

        private void Update()
        {
            if (_agent.hasPath && _agent.hasPath)
                _anim.SetFloat(SPEED_PARAM, _agent.velocity.magnitude);
        }
    }
}
