using System.Collections.Generic;
using GameInit.Utility;
using UnityEngine;

namespace GameInit.Component
{
    [RequireComponent(typeof(ObjectPoolUnity))]
    [RequireComponent(typeof(Rigidbody))]
    public class NomadsCampComponent : MonoBehaviour
    {
        [field: SerializeField] public int SpawnCount { get; private set; }
        public ObjectPoolUnity ObjectPoolUnity { get; private set; }

        private List<NomadComponent> _nomads;

        private void Awake()
        {
            GetComponent<Rigidbody>().isKinematic = true;
            _nomads = new List<NomadComponent>(4);
            ObjectPoolUnity = GetComponent<ObjectPoolUnity>();
        }

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            var random = Random.Range(1, SpawnCount + 1);
            for (int i = 0; i < random; i++)
            {
                var nomad = ObjectPoolUnity.Pool.Get();
                _nomads.Add(nomad.GetComponent<NomadComponent>());
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Coin coin))
            {
                for (int i = 0; i < _nomads.Count; i++)
                {
                    if (_nomads[i].goesForACoinCoroutine == null && _nomads[i].IsGoingForACoin == false)
                    {
                        StartCoroutine(_nomads[i].GoesForACoinCoroutine(coin));
                        return;
                    }
                }
            }
        }
    }
}
