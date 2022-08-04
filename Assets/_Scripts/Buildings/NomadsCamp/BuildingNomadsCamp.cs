using System.Collections.Generic;
using UnityEngine;

public class BuildingNomadsCamp : BuildingBase
{
    [SerializeField] private int _nomadsCountToSpawn = 4;
    [SerializeField] private float _spawnRadius = 10f;
    [SerializeField] private GameObject _nomadPrefab;

    private int coinIndex;
    private List<Nomad> _nomads;

    private void Awake()
    {
        _nomads = new List<Nomad>(4);
    }

    public override void Start()
    {
        base.Start();

        for (int i = 0; i < _nomadsCountToSpawn; i++)
        {
            Vector3 spawnLocation = Random.insideUnitCircle * _spawnRadius;
            spawnLocation.y = transform.position.y;
            var go = Instantiate(_nomadPrefab, transform.position + spawnLocation, Quaternion.identity);
            var nomad = go.GetComponent<Nomad>();
            nomad.BuildingNomadsCamp = this;
            _nomads.Add(nomad);
        }
    }

    public void DeleteNomadFromList(Nomad nomad)
    {
        _nomads.Remove(nomad);
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
