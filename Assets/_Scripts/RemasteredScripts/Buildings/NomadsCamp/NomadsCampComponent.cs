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
        public List<NomadComponent> Nomads { get; private set; }
        public ObjectPoolUnity NomadPool { get; set; }

        private void Awake()
        {
            GetComponent<Rigidbody>().isKinematic = true;
            Nomads = new List<NomadComponent>(4);
            NomadPool = GetComponent<ObjectPoolUnity>();
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
                var nomad = NomadPool.Pool.Get();
                Nomads.Add(nomad.GetComponent<NomadComponent>());
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Coin coin))
            {
                for (int i = 0; i < Nomads.Count; i++)
                {
                    if (Nomads[i].GoesForACoinCoroutine == null && Nomads[i].IsGoingForACoin == false)
                    {
                        StartCoroutine(Nomads[i].GoesForACoin(coin));
                        return;
                    }
                }
            }
        }
    }
}
