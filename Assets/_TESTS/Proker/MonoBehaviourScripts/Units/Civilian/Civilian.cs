using UnityEngine;
using UnityEngine.AI;

namespace BOYAREGames.Units
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Civilian : MonoBehaviour
    {
        public NavMeshAgent Agent { get; private set; }
        public Vector3 OriginalDestination { get; private set; }

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
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
            SetDestination(destination);
        }
    }
}
