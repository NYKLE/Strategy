using UnityEngine;
using UnityEngine.AI;

public class HeroSettings : MonoBehaviour
{
    public Transform Transform { get; private set; }
    public NavMeshAgent Agent { get; private set; }

    private void Awake()
    {
        Transform = transform;
        Agent = GetComponent<NavMeshAgent>();
    }
}
