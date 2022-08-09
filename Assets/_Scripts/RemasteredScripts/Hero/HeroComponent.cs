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
        if (other.gameObject.GetComponent<Coin>() && other.gameObject.GetComponent<Coin>().CanPickUp)
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
