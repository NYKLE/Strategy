using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.Job;

public class CitizenState : IJob
{
    public CitizenState()
    {
        Enter();
    }
    public void Enter()
    {
        Debug.Log("New Citezen in the House!");
    }
}
