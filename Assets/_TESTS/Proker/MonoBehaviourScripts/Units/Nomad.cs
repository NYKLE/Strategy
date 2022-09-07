using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace BOYAREGames.Units
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Nomad : MonoBehaviour
    {
        [Header("Prefab")]
        [SerializeField] private GameObject _civilianPrefab;

        [Header("FX Settings")] 
        [SerializeField] private float _disappearDelay = 1f;

        public bool IsFree = true;

        private NavMeshAgent _agent;

        private Coroutine _disappearCoroutine;
        private WaitForSeconds _waitForDisappearDelay;
        private Coroutine _patrolCoroutine;
        private WaitForSeconds _waitForPatrolStandDelay;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();

            _waitForDisappearDelay = new WaitForSeconds(_disappearDelay);
            _waitForPatrolStandDelay = new WaitForSeconds(Random.Range(2f, 4f));
        }

        private void Start()
        {
            _patrolCoroutine ??= StartCoroutine(Patrol());
        }

        private void Update()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Collectable.Coin coin))
            {
                Destroy(coin.gameObject);

                _disappearCoroutine ??= StartCoroutine(Disappear(_disappearDelay));
            }
        }

        private IEnumerator Patrol()
        {
            yield return _waitForPatrolStandDelay;

            var randomPosition = (Vector3)Random.insideUnitCircle * 3f;
            randomPosition += transform.position;
            GoToDestination(randomPosition);

            _patrolCoroutine = null;

            _patrolCoroutine ??= StartCoroutine(Patrol());
        }

        private void GoToPatrol(Vector3 destination)
        {
            _agent.SetDestination(destination);
        }

        public void GoToDestination(Vector3 destination)
        {
            StopCoroutine(_patrolCoroutine);

            _agent.SetDestination(destination);
        }

        private IEnumerator Disappear(float waitTime)
        {
            // TODO: DO FX

            yield return _waitForDisappearDelay;

            GameObject go = Instantiate(_civilianPrefab, transform.position, Quaternion.identity);
            Events.Events.Nomad.DestroyAction?.Invoke(this);
            Destroy(gameObject);

            _disappearCoroutine = null;
        }
    }
}
