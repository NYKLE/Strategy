using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace BOYAREGames.Units
{
    [RequireComponent(typeof(Civilian))]
    [RequireComponent(typeof(SphereCollider))]
    public class CivilianPickCoin : MonoBehaviour
    {
        [SerializeField] private GameObject _coinPrefab;
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

        private void OnTriggerEnter(Collider other)
        {
            if (_coinPocketCurrent > 0)
            {
                if (other.TryGetComponent(out Player.Player player))
                {
                    for (int i = 0; i < _coinPocketCurrent; i++)
                    {
                        GameObject go = Instantiate(_coinPrefab, transform.position, Quaternion.identity);
                        Vector3 direction = player.transform.position - transform.position;
                        direction.y += 1f;
                        go.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
                    }
                }
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
