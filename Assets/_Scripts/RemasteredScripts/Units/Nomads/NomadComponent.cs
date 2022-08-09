using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace GameInit.Component
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NomadComponent : MonoBehaviour
    {
        //[field: SerializeField] public ObjectPoolUnity CitizenPool { get; private set; }
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

            // coin.Hide();
            // _renderer.enabled = false;
            //
            // var go = CitizenPool.Pool.Get();
            // go.transform.position = transform.position;
            //
            // Destroy(gameObject);

            GoesForACoinCoroutine = null;
        }
    }
}
