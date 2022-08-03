using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Hero : MonoBehaviour, ISelectable, IMoveable
{
    private NavMeshAgent _agent;
    private SpriteRenderer _selectedSprite;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _selectedSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void OnSelect()
    {
        _selectedSprite.enabled = true;
    }

    public void OnDeselect()
    {
        _selectedSprite.enabled = false;
    }

    public void MoveToPos(RaycastHit hit)
    {
        _agent.SetDestination(hit.point);
    }

    private void OnEnable()
    {
        Events.Cursor.onDeselect += OnDeselect;
    }

    private void OnDisable()
    {
        Events.Cursor.onDeselect -= OnDeselect;
    }
}
