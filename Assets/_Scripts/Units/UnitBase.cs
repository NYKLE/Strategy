using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class UnitBase : MonoBehaviour
{
    public NavMeshAgent Agent { get; private set; }

    [field: SerializeField] public int Health { get; private set; }

    public virtual void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }
}
