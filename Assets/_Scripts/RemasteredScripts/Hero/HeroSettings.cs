using UnityEngine;
using UnityEngine.AI;

public class HeroSettings : MonoBehaviour
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
}
