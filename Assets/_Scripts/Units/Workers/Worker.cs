using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Worker : MonoBehaviour, ISelectable
{
    public static Action<GameObject> OnReleaseWorker;

    [SerializeField] private Workerstate _state;

    private NavMeshAgent _agent;
    private ResourceZone _zone;
    private RaycastHit hit;
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
        Setstate(Workerstate.Walking);
    }

    public void ReturnWorker(Vector3 ratusha, ResourceZone zone)
    {
        _isReturning = true;
        _isReachedDestination = false;

        gameObject.SetActive(true);

        _agent.SetDestination(ratusha);

        Setstate(Workerstate.Returning);
    }

    public void Setstate(Workerstate state)
    {
        _state = state;
    }

    public Workerstate Getstate()
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
                        Setstate(Workerstate.Free);

                        _zone = null;

                        _isReturning = false;

                        _isReachedDestination = true;
                    }
                }
                else
                {
                    _isReturning = true;
                    Setstate(Workerstate.Returning);

                    _isReachedDestination = false;
                }
            }
            else
            {
                if (_agent.remainingDistance <= 1f)
                {
                    if (_isReachedDestination == false)
                    {
                        Setstate(Workerstate.Working);

                        gameObject.SetActive(false);

                        _isReachedDestination = true;
                    }
                }
                else
                {
                    Setstate(Workerstate.Walking);

                    _isReachedDestination = false;
                }
            }
        }
        if (hit.point != Vector3.zero)
        {
            Setstate(Workerstate.Walking);
            _agent.SetDestination(hit.point);
        }
        else
        {
            Setstate(Workerstate.Waiting);
        }
    }
    public void MoveToPos(RaycastHit _hit)
    {
        hit.point = _hit.point;
    }

    public void OnSelect()
    {
     //   throw new System.NotImplementedException();
    }

    public void OnDeselect()
    {
        
    }
}
