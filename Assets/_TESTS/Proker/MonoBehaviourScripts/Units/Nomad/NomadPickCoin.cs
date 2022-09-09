using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace BOYAREGames.Units
{
    [RequireComponent(typeof(Nomad))]
    public class NomadPickCoin : MonoBehaviour
    {
        [Header("Prefab")]
        [SerializeField] private GameObject _civilianPrefab;

        [Header("FX Settings")]
        [SerializeField] private float _disappearDelay = 1f;

        private Nomad _nomad;
        private Collectable.Coin _coin;

        private Coroutine _goToCoinCoroutine;
        private Coroutine _disappearCoroutine;
        private WaitForSeconds _waitForDisappearDelay;

        private void Awake()
        {
            _nomad = GetComponent<Nomad>();

            _waitForDisappearDelay = new WaitForSeconds(_disappearDelay);
        }

        public void GoToCoin(Collectable.Coin coin)
        {
            _goToCoinCoroutine ??= StartCoroutine(GoToCoinCoroutine(coin));
        }

        private IEnumerator GoToCoinCoroutine(Collectable.Coin coin)
        {
            _coin = coin;
            Vector3 coinPosition = coin.transform.position;
            NavMeshAgent agent = _nomad.Agent;

            _nomad.IsFree = false;
            _nomad.Patrol.StopPatrol();

            agent.SetDestination(coinPosition);

            while (agent.hasPath &&
                   Vector3.Distance(coinPosition, transform.position) > agent.stoppingDistance &&
                _coin != null)
            {
                yield return null;
            }

            if (_coin != null)
            {
                Destroy(coin.gameObject);

                _disappearCoroutine ??= StartCoroutine(Disappear(_disappearDelay));
            }
            else
            {
                _nomad.Patrol.StartPatrol();
            }

            _goToCoinCoroutine = null;
        }

        private IEnumerator Disappear(float waitTime)
        {
            // TODO: DO FX

            yield return _waitForDisappearDelay;

            GameObject go = Instantiate(_civilianPrefab, transform.position, Quaternion.identity);
            Events.Events.Nomad.onDestroyAction?.Invoke(_nomad);
            Destroy(gameObject);

            _disappearCoroutine = null;
        }

        private void OnEnable()
        {
            Events.Events.Coin.onDestroyAction += OnCoinDestroy;
        }

        private void OnDisable()
        {
            Events.Events.Coin.onDestroyAction -= OnCoinDestroy;
        }

        private void OnCoinDestroy(Collectable.Coin coin)
        {
            if (_coin == coin)
            {
                _coin = null;

                Debug.Log("Coin Was Destroyed");
            }
        }
    }
}
