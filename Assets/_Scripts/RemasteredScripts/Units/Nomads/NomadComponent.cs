using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace GameInit.Component
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NomadComponent : MonoBehaviour
    {
        public bool IsCollided { get; private set; }
        public bool IsGoingForACoin { get; set; }
        public Coin Coin { get; private set; }
        public Coroutine GoesForACoinCoroutine { get; set; }

        private NavMeshAgent _agent;
        private Renderer _renderer;

        public void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _agent = GetComponent<NavMeshAgent>();
        }

        public IEnumerator GoesForACoin(Coin coin)
        {
            Coin = coin;
            IsGoingForACoin = true;
            _agent.SetDestination(coin.transform.position);

            while (Vector3.Distance(transform.position, coin.transform.position) > _agent.stoppingDistance)
            {
                yield return null;
            }

            IsCollided = true;

            GoesForACoinCoroutine = null;
        }
    }
}
