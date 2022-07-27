using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitsManager : MonoBehaviour
{
    public static UnitsManager Instance; 

    public static Action<GameObject> onUnitSpawn;
    public static Action<GameObject> onUnitDeath;

    private List<GameObject> _units = new List<GameObject>(100);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnAdd(GameObject go)
    {
        _units.Add(go);
    }

    private void OnDeath(GameObject go)
    {
        _units.Remove(go);
    }

    private void OnEnable()
    {
        onUnitSpawn += OnAdd;
        onUnitDeath += OnDeath;
    }

    private void OnDisable()
    {
        onUnitSpawn -= OnAdd;
        onUnitDeath -= OnDeath;
    }

    public List<GameObject> GetUnitsList()
    {
        return _units;
    }
}
