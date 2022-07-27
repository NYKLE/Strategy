using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Worker : MonoBehaviour, ISelectable
{
    [SerializeField] private WorkerState _state;

    private NavMeshAgent _agent;
    private ResourceZone _zone;
    private RaycastHit hit;
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
        if (hit.point != Vector3.zero)
        {
            SetState(WorkerState.Walking);
            _agent.SetDestination(hit.point);
        }
        else
        {
            SetState(WorkerState.Waiting);
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
}
