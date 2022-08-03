using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFarm : BuildingBase
{
    public override void Start()
    {
        base.Start();
    }

    public override void OnEnable()
    {
        base.OnEnable();

        Events.Time.onMidday += OnMidday;
        Events.Time.onNight += OnNight;
    }

    public override void OnDisable()
    {
        base.OnDisable();

        Events.Time.onNight -= OnMidday;
        Events.Time.onNight -= OnNight;
    }

    private void OnMidday()
    {
        Debug.Log("Midday");
    }

    private void OnNight()
    {
        Debug.Log("Night");
    }
}
