using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace GameInit.Component
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NomadComponent : MonoBehaviour
    {
        [field: SerializeField] public GameObject CitizenPrefab { get; private set; }
        public bool IsGoingForACoin { get; set; }
        public Coroutine goesForACoinCoroutine { get; private set; }

        private NavMeshAgent _agent;
        private Renderer _renderer;

        public void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _agent = GetComponent<NavMeshAgent>();
        }

        public IEnumerator GoesForACoinCoroutine(Coin coin)
        {
            IsGoingForACoin = true;
            _agent.SetDestination(coin.transform.position);

            while (Vector3.Distance(transform.position, coin.transform.position) > _agent.stoppingDistance)
            {
                yield return null;
            }

            coin.Hide();
            _renderer.enabled = false;

            yield return new WaitForSeconds(1f);

            var go = Instantiate(CitizenPrefab, transform.position, Quaternion.identity);


            Destroy(gameObject);

            goesForACoinCoroutine = null;
        }
    }
}
