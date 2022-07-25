using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Worker : MonoBehaviour
{
    [SerializeField] private WorkerState _state;

    private NavMeshAgent _agent;
    private ResourceZone _zone;

    private bool _isReachedDestination;

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

    public void SetState(WorkerState state)
    {
        _state = state;
    }

    public WorkerState GetState()
    {
        return _state;
    }

    private void Update()
    {
        if (_agent.hasPath && _agent.remainingDistance <= 1f)
        {
            if (_isReachedDestination == false)
            {
                SetState(WorkerState.Working);
                _zone.AddWorker(this);

                _isReachedDestination = true;
                gameObject.SetActive(false);
            }
        }
    }
}
