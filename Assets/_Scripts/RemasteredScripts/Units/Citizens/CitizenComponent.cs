using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace GameInit.Component
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CitizenComponent : MonoBehaviour
    {
        [field: SerializeField] public int CoinMaxCanHave { get; private set; }
        public int CoinCurrentHave { get; private set; }
        public bool IsGoingForACoin { get; private set; }
        //public bool IsReachedCoin { get; private set; }
        public bool IsCoinsInRadius { get; private set; }
        public NavMeshAgent Agent { get; private set; }

        private Coroutine _goesForACoinCoroutine;
        private WaitForEndOfFrame _waitForEndOfFrame;
        private Coin _coin;

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            _waitForEndOfFrame = new WaitForEndOfFrame();
        }

        private void Start()
        {
            CoinMaxCanHave = 5;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out Coin coin))
            {
                if (CoinCurrentHave < CoinMaxCanHave)
                {
                    IsCoinsInRadius = true;
                    _coin = coin;
                }
            }
        }

        // private void OnTriggerExit(Collider other)
        // {
        //     if (other.TryGetComponent(out Coin coin))
        //     {
        //         IsCoinsInRadius = false;
        //         _coin = null;
        //     }
        // }

        public void GoesForACoin()
        {
            if (_goesForACoinCoroutine == null)
            {
                _goesForACoinCoroutine = StartCoroutine(GoesForACoinCoroutine());
            }
        }

        private IEnumerator GoesForACoinCoroutine()
        {
            if (_coin != null)
            {
                IsGoingForACoin = true;
                Agent.SetDestination(_coin.transform.position);

                while (Vector3.Distance(transform.position, _coin.transform.position) > Agent.stoppingDistance && _coin.gameObject.activeSelf)
                {
                    Debug.Log("Coroutine is Going");
                    Agent.SetDestination(_coin.transform.position);
                    yield return null;
                }

                IsGoingForACoin = false;

                if (_coin != null)
                {
                    _coin.Hide();
                    CoinCurrentHave++;
                }
            }

            IsCoinsInRadius = false;
            _coin = null;

            _goesForACoinCoroutine = null;
        }
    }
}
