using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.Job;
using GameInit.ConnectBuildings;
using UnityEngine.AI;

public class CitizenState : IJob
{
    private GameObject prefab;
    private NavMeshAgent navMesh;
    public CitizenState(GameObject _prefab, NavMeshAgent _navMesh)
    {
        navMesh = _navMesh;
        prefab = _prefab;
        Enter();
    }
    public void Enter()
    {
        Debug.Log("New Citezen in the House!");
    }

    public Vector3 getPosition()
    {
        return prefab.transform.position;
    }

    public void setWay(Vector3 way)
    {
        navMesh.SetDestination(way);
    }
}
