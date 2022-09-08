using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOYAREGames.Units
{
    [RequireComponent(typeof(Civilian))]
    [RequireComponent(typeof(SphereCollider))]
    public class CivilianPickCoin : MonoBehaviour
    {
        [SerializeField] private float _coinSightRadius = 5f;
        [SerializeField] private int _coinPocketMax = 5;

        private SphereCollider _sphereCollider;
        private Civilian _civilian;
        private Coroutine _goForCoinCoroutine;
        private Collectable.Coin _coinToPickUp;

        private List<Collectable.Coin> _coinsInSight = new List<Collectable.Coin>();
        private int _coinPocketCurrent;

        private void Awake()
        {
            _sphereCollider = GetComponent<SphereCollider>();
            _civilian = GetComponent<Civilian>();
        }

        private void Start()
        {
            _sphereCollider.radius = _coinSightRadius;
        }

        private void Update()
        {
            if (_coinsInSight.Count > 0)
            {
                _goForCoinCoroutine ??= StartCoroutine(GoForCoin(_coinsInSight[0]));
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (_coinPocketCurrent < _coinPocketMax)
            {
                if (other.TryGetComponent(out Collectable.Coin coin))
                {
                    if (!_coinsInSight.Contains(coin))
                    {
                        _coinsInSight.Add(coin);
                    }
                }
            }
        }

        private IEnumerator GoForCoin(Collectable.Coin coin)
        {
            _coinToPickUp = coin;
            Vector3 coinPosition = coin.transform.position;
            _civilian.Agent.SetDestination(coinPosition);

            while (_civilian.Agent.hasPath && 
                   Vector3.Distance(transform.position, coinPosition) >= _civilian.Agent.stoppingDistance)
            {
                yield return null;
            }

            if (_coinToPickUp != null)
            {
                _coinPocketCurrent++;
                Destroy(coin.gameObject);
                _coinsInSight.Clear();
            }

            _coinToPickUp = null;
            _goForCoinCoroutine = null;

            _civilian.Agent.SetDestination(_civilian.OriginalDestination);
        }

        private void OnEnable()
        {
            Events.Events.Coin.onDestroyAction += OnDestroyCoin;
        }

        private void OnDisable()
        {
            Events.Events.Coin.onDestroyAction -= OnDestroyCoin;
        }

        private void OnDestroyCoin(Collectable.Coin coin)
        {
            if (_coinsInSight.Contains(coin))
            {
                _coinToPickUp = null;
                _coinsInSight.Clear();
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _coinSightRadius);
        }
    }
}
