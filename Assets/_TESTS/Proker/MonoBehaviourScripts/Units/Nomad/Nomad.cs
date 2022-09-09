using UnityEngine;
using UnityEngine.AI;

namespace BOYAREGames.Units
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(NomadPatrol))]
    [RequireComponent(typeof(NomadPickCoin))]
    public class Nomad : MonoBehaviour
    {
        [HideInInspector] public bool IsFree = true;

        public NavMeshAgent Agent { get; private set; }
        public NomadPickCoin PickCoin { get; private set; }
        public NomadPatrol Patrol { get; private set; }

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            Patrol = GetComponent<NomadPatrol>();
            PickCoin = GetComponent<NomadPickCoin>();
        }
    }
}
