using System.Collections.Generic;
using UnityEngine;

namespace BOYAREGames.Camps
{
    [RequireComponent(typeof(SphereCollider))]
    public class NomadsCamp : MonoBehaviour
    {
        [SerializeField] private GameObject _nomadPrefab;
        [SerializeField] private float _spawnRadius = 8f;
        [SerializeField] private float _coinPickRadius = 12f;

        private SphereCollider _sphereCollider;

        private List<Units.Nomad> _nomads = new List<Units.Nomad>();

        private void Awake()
        {
            _sphereCollider = GetComponent<SphereCollider>();
        }

        private void Start()
        {
            _sphereCollider.radius = _coinPickRadius;
            int randomAmountOfNomads = Random.Range(3, 5);

            for (int i = 0; i < randomAmountOfNomads; i++)
            {
                Spawn();
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Collectable.Coin coin))
            {
                foreach (var nomad in _nomads)
                {
                    if (nomad.IsFree)
                    {
                        nomad.GoToDestination(coin.transform.position);
                        return;
                    }
                }
            }
        }

        public void Spawn()
        {
            var randomPosition = (Vector3)Random.insideUnitCircle * _spawnRadius;
            randomPosition += transform.position;
            GameObject go = Instantiate(_nomadPrefab, randomPosition, transform.rotation);
            if (go.TryGetComponent(out Units.Nomad nomad))
            {
                _nomads.Add(nomad);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, _spawnRadius);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _coinPickRadius);
        }
    }
}
