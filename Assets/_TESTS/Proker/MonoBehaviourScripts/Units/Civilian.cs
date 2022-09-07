using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BOYAREGames.Units
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(SphereCollider))]
    public class Civilian : MonoBehaviour
    {
        [SerializeField] private float _coinSightRadius = 5f;
        [SerializeField] private int _coinPocketMax = 5;

        private NavMeshAgent _agent;
        private SphereCollider _sphereCollider;
        private Vector3 _originalDestination;

        private List<Collectable.Coin> _coinsInSight = new List<Collectable.Coin>();
        private int _coinPocketCurrent;
        private bool _isGoingForCoin;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _sphereCollider = GetComponent<SphereCollider>();
        }

        private void Start()
        {
            Events.Events.Civilian.Spawn?.Invoke(this);

            _sphereCollider.radius = _coinSightRadius;
        }

        private void Update()
        {
            if (_isGoingForCoin)
            {
                if (!_agent.hasPath)
                {
                    _isGoingForCoin = false;
                    _coinPocketCurrent++;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Collectable.Coin coin))
            {
                if (_coinPocketCurrent < _coinPocketMax)
                {
                    _coinsInSight.Add(coin);

                    _isGoingForCoin = true;
                    SetDestination(coin.transform.position);
                }
            }
        }

        public void SetDestination(Vector3 destination)
        {
            _agent.SetDestination(destination);
        }

        public void GoToGatheringPoint(Vector3 destination)
        {
            _originalDestination = destination;
            _agent.SetDestination(destination);
        }

        private void OnValidate()
        {
            _sphereCollider.radius = _coinSightRadius;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _coinSightRadius);
        }
    }
}
