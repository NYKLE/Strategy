using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Renderer))]
public class Nomad : UnitBase
{
    [SerializeField] private GameObject _villagerPrefab;
    public BuildingNomadsCamp BuildingNomadsCamp { get; set; }
    public NavMeshAgent Agent { get; private set; }

    private Renderer _renderer;
    public Coroutine goesForACoinCoroutine { get; private set; }
    public bool IsGoingForACoin { get; set; }

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        _renderer = GetComponent<Renderer>();
    }

    public IEnumerator GoesForACoinCoroutine(Coin coin)
    {
        IsGoingForACoin = true;
        Agent.SetDestination(coin.transform.position);

        while (Vector3.Distance(transform.position, coin.transform.position) > Agent.stoppingDistance)
        {
            yield return null;
        }

        coin.Hide();
        _renderer.enabled = false;
        BuildingNomadsCamp.DeleteNomadFromList(this);

        yield return new WaitForSeconds(1f);

        var siblingIndex = transform.GetSiblingIndex();
        var go = Instantiate(_villagerPrefab, transform.position, Quaternion.identity);
        go.transform.SetSiblingIndex(siblingIndex);

        Destroy(gameObject);

        goesForACoinCoroutine = null;
    }
}
