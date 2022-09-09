using System.Collections;
using UnityEngine;

namespace BOYAREGames.Units
{
    [RequireComponent(typeof(Nomad))]
    public class NomadPatrol : MonoBehaviour
    {
        [SerializeField] private Vector2 _waitTimeRange;
        private Nomad _nomad;

        private Coroutine _patrolCoroutine;
        private WaitForSeconds _waitForPatrolStandDelay;

        private void Awake()
        {
            _nomad = GetComponent<Nomad>();

            _waitForPatrolStandDelay = new WaitForSeconds(Random.Range(_waitTimeRange.x, _waitTimeRange.y));
        }

        private void Start()
        {
            StartPatrol();
        }

        private IEnumerator Patrol()
        {
            yield return _waitForPatrolStandDelay;

            var randomPosition = (Vector3)Random.insideUnitCircle * 3f;
            randomPosition += transform.position;
            _nomad.Agent.SetDestination(randomPosition);

            _patrolCoroutine = null;

            _patrolCoroutine ??= StartCoroutine(Patrol());
        }

        public void StartPatrol()
        {
            _patrolCoroutine ??= StartCoroutine(Patrol());
        }

        public void StopPatrol()
        {
            StopCoroutine(_patrolCoroutine);
            _patrolCoroutine = null;
        }
    }
}
