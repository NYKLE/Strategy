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

        [HideInInspector] public bool IsFree = true;

        private NavMeshAgent _agent;
        private Coroutine _disappearCoroutine;
        private WaitForSeconds _waitForDisappearDelay;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();

            _waitForDisappearDelay = new WaitForSeconds(_disappearDelay);
        }

        private void Update()
        {
            IsFree = !_agent.hasPath;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Collectable.Coin coin))
            {
                Destroy(coin.gameObject);

                if (_disappearCoroutine == null)
                {
                    _disappearCoroutine = StartCoroutine(Disappear(_disappearDelay));
                }
            }
        }

        public void GoToDestination(Vector3 destination)
        {
            _agent.SetDestination(destination);
        }

        private IEnumerator Disappear(float waitTime)
        {
            yield return _waitForDisappearDelay;

            GameObject go = Instantiate(_civilianPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);

            _disappearCoroutine = null;
        }
    }
}
