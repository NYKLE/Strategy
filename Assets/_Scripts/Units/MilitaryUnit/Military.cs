using UnityEngine;
using UnityEngine.AI;
using Unity;
[RequireComponent(typeof(NavMeshAgent))]
public class Military : MonoBehaviour, ISelectable, IMoveable
{
    [SerializeField] private MillitaryState _state;

    [SerializeField] private SpriteRenderer _selectedSprite;

    private NavMeshAgent _agent;
    private RaycastHit hit;

    private bool _isReachedDestination;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        UnitsManager.onUnitSpawn?.Invoke(gameObject);
    }

    public void SendMilitary(Vector3 destination)
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
        _selectedSprite.enabled = true;
    }

    public void MoveToPos(RaycastHit _hit)
    {
        hit.point = _hit.point;
    }

    public void OnEnable()
    {
        

        Cursor.onDeselect += OnDeselect;
    }

    public void OnDisable()
    {
        UnitsManager.onUnitDeath?.Invoke(gameObject);

        Cursor.onDeselect -= OnDeselect;
    }

    private void OnDeselect()
    {
        _selectedSprite.enabled = false;
    }
}
