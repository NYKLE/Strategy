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
    private List<Worker> _walkingWorkers;
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

        _workers = new List<Worker>(_maximumAmount);
        _freeWorkers = new List<Worker>(_maximumAmount);
        _walkingWorkers = new List<Worker>(_maximumAmount);

        PoolSetup();
    }

    public void Start()
    {
        SpawnWorker(_maximumAmount);
    }

    public void SpawnWorker(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            _workerPool.Get();
        }
    }

    public GameObject SpawnSingleWorker()
    {
        return _workerPool.Get();
    }

    public List<Worker> GetWorkers()
    {
        return _workers;
    }

    public List<Worker> CheckForWalkingWorkers()
    {
        _walkingWorkers.Clear();

        foreach (var worker in _workers)
        {
            if (worker.Getstate() == Workerstate.Walking)
            {
                _walkingWorkers.Add(worker);
            }
        }

        return _walkingWorkers;
    }

    public List<Worker> CheckForFreeWorkers()
    {
        _freeWorkers.Clear();

        foreach (var worker in _workers)
        {
            if (worker.Getstate() == Workerstate.Free)
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
    }

    private void OnWorkerDestroy(GameObject go)
    {
        _workers.Remove(go.GetComponent<Worker>());

        Destroy(go);
    }

    private void OnEnable()
    {
        Worker.OnReleaseWorker += OnReleaseWorker;
    }

    private void OnDisable()
    {
        Worker.OnReleaseWorker -= OnReleaseWorker;
    }

    private void OnReleaseWorker(GameObject go)
    {
        _workerPool.Release(go);
    }
}
