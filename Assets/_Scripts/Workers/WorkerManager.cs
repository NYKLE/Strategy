using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class WorkerManager : MonoBehaviour
{
    public static WorkerManager Instance;

    [SerializeField] private int _maximumAmount = 10;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _prefab;

    [Header("Pool Settings")] 
    [SerializeField] private bool _collectionChecks = true;
    [SerializeField] private int _defaultCapacity = 10;
    [SerializeField] private int _maxPoolSize = 100;

    private List<Worker> _workers;
    private List<Worker> _freeWorkers;
    private ObjectPool<GameObject> _workerPool;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        _workers = new List<Worker>(10);
        _freeWorkers = new List<Worker>(10);

        PoolSetup();
    }

    public void Start()
    {
        SpawnWorker(10);
    }

    public void SpawnWorker(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            _workerPool.Get();
        }
    }

    public List<Worker> CheckForFreeWorkers()
    {
        _freeWorkers.Clear();

        foreach (var worker in _workers)
        {
            if (worker.GetState() == WorkerState.Free)
            {
                _freeWorkers.Add(worker);
            }
        }

        return _freeWorkers;
    }

    private void PoolSetup()
    {
        _workerPool = new ObjectPool<GameObject>(
            OnWorkerInstantiate,
            OnWorkerGet,
            OnWorkerRelease,
            OnWorkerDestroy,
            _collectionChecks,
            _defaultCapacity,
            _maxPoolSize);
    }

    private GameObject OnWorkerInstantiate()
    {
        return Instantiate(_prefab);
    }

    private void OnWorkerGet(GameObject go)
    {
        go.SetActive(true);
        go.transform.position = _spawnPoint.position;

        _workers.Add(go.GetComponent<Worker>());
    }

    private void OnWorkerRelease(GameObject go)
    {
        go.SetActive(false);

        _workers.Remove(go.GetComponent<Worker>());
    }

    private void OnWorkerDestroy(GameObject go)
    {
        _workers.Remove(go.GetComponent<Worker>());

        Destroy(go.gameObject);
    }
}
