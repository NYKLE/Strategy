using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Military : MonoBehaviour, ISelectable, IMoveable
{
    [SerializeField] private Millitarystate _state;

    [SerializeField] private SpriteRenderer _selectedSprite;

    private NavMeshAgent _agent;
    private RaycastHit hit;

    private bool _isReachedDestination;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        Events.Unit.onUnitSpawn?.Invoke(gameObject);
    }

    public void SendMilitary(Vector3 destination)
    {
        _isReachedDestination = false;

        _agent.SetDestination(destination);
        Setstate(Millitarystate.Walking);
    }

    public void Setstate(Millitarystate state)
    {
        _state = state;
    }

    public Millitarystate Getstate()
    {
        return _state;
    }

    private void Update()
    {
        if (hit.point != null)
        {
            Setstate(Millitarystate.Walking);
            _agent.SetDestination(hit.point);
        }
        else
        {
            Setstate(Millitarystate.Waiting);
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
        Events.Cursor.onDeselect += OnDeselect;
    }

    public void OnDisable()
    {
        Events.Unit.onUnitDeath?.Invoke(gameObject);

        Events.Cursor.onDeselect -= OnDeselect;
    }

    public void OnDeselect()
    {
        _selectedSprite.enabled = false;
    }
}
