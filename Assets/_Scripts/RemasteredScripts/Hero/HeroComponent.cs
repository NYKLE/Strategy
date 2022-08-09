using UnityEngine;
using UnityEngine.AI;

public class HeroComponent : MonoBehaviour, ISelectable
{
    public Transform Transform { get; private set; }
    public NavMeshAgent Agent { get; private set; }
    private Coin coin;

    private void Awake()
    {
        Transform = transform;
        Agent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var _coin = other.gameObject.GetComponent<Coin>();
        if (_coin && _coin.CanPickUp) 
        { 
            coin = other.gameObject.GetComponent<Coin>();
        }
    }
    public Coin GetCoin()
    {
        return coin;
    }

    public void OnSelect()
    {
        
    }

    public void OnDeselect()
    {
        
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
