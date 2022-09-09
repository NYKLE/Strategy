using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace BOYAREGames.Units
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(CivilianPickCoin))]
    public class Civilian : MonoBehaviour
    {
        public NavMeshAgent Agent { get; private set; }
        public Vector3 OriginalDestination { get; private set; }

        private CivilianPickCoin _civilianPickCoin;
        private Coroutine _gotoGatheringPointCoroutine;

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();

            _civilianPickCoin = GetComponent<CivilianPickCoin>();
            _civilianPickCoin.enabled = false;
        }

        private void Start()
        {
            Events.Events.Civilian.onSpawnAction?.Invoke(this);
        }

        public void SetDestination(Vector3 destination)
        {
            OriginalDestination = destination;
            Agent.SetDestination(destination);
        }

        public void GoToGatheringPoint(Vector3 destination)
        {
            _gotoGatheringPointCoroutine ??= StartCoroutine(GoToGatheringPointCoroutine(destination));
        }

        private IEnumerator GoToGatheringPointCoroutine(Vector3 destination)
        {
            _civilianPickCoin.enabled = false;

            SetDestination(destination);

            while (Agent.hasPath &&
                   Vector3.Distance(destination, transform.position) > Agent.stoppingDistance)
            {
                yield return null;
            }

            _civilianPickCoin.enabled = true;

            _gotoGatheringPointCoroutine = null;
        }
    }
}
