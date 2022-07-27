using UnityEngine;
using UnityEngine.AI;
using Unity;
[RequireComponent(typeof(NavMeshAgent))]
public class Millitary : MonoBehaviour, ISelectable
{
    [SerializeField] private MillitaryState _state;

    private NavMeshAgent _agent;
    private RaycastHit hit;

    private bool _isReachedDestination;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void SendMillitary(Vector3 destination)
    {
        _isReachedDestination = false;

        _agent.SetDestination(destination);
        SetState(MillitaryState.Walking);
    }

    public void SetState(MillitaryState state)
    {
        _state = state;
    }

    public MillitaryState GetState()
    {
        return _state;
    }

    private void Update()
    {
        if (hit.point != null)
        {
            SetState(MillitaryState.Walking);
            _agent.SetDestination(hit.point);
        }
        else
        {
            SetState(MillitaryState.Waiting);
        }
    }

    public void OnSelect()
    {
        
    }

    public void MoveToPos(RaycastHit _hit)
    {
        hit.point = _hit.point;
    }
}
