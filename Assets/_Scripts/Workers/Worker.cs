using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Worker : MonoBehaviour
{
    public static Action<GameObject> OnReleaseWorker;

    [SerializeField] private WorkerState _state;

    private NavMeshAgent _agent;
    private ResourceZone _zone;

    private bool _isReachedDestination;
    private bool _isReturning;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void SendToWork(Vector3 destination, ResourceZone zone)
    {
        _zone = zone;
        _isReachedDestination = false;

        _agent.SetDestination(destination);
        SetState(WorkerState.Walking);
    }

    public void ReturnWorker(Vector3 ratusha, ResourceZone zone)
    {
        _isReturning = true;
        _isReachedDestination = false;

        gameObject.SetActive(true);
        gameObject.transform.position = zone.GetEnterExitPoint();

        _agent.SetDestination(ratusha);

        SetState(WorkerState.Returning);
    }

    public void SetState(WorkerState state)
    {
        _state = state;
    }

    public WorkerState GetState()
    {
        return _state;
    }

    public ResourceZone GetResourceZone()
    {
        return _zone;
    }

    private void Update()
    {
        if (_agent.hasPath)
        {
            if (_isReturning)
            {
                if (_agent.remainingDistance <= 1f)
                {
                    if (_isReachedDestination == false)
                    {
                        SetState(WorkerState.Free);

                        _zone.RemoveWorker(this);
                        _zone.UpdateWindowData();
                        _zone = null;

                        _isReturning = false;

                        _isReachedDestination = true;
                    }
                }
                else
                {
                    _isReturning = true;
                    SetState(WorkerState.Returning);

                    _isReachedDestination = false;
                }
            }
            else
            {
                if (_agent.remainingDistance <= 1f)
                {
                    if (_isReachedDestination == false)
                    {
                        SetState(WorkerState.Working);
                        _zone.UpdateWindowData();

                        gameObject.SetActive(false);

                        _isReachedDestination = true;
                    }
                }
                else
                {
                    SetState(WorkerState.Walking);

                    _isReachedDestination = false;
                }
            }
        }
    }
}
