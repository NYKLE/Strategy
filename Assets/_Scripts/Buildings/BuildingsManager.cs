using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingsManager
{
    public List<Building> Buildings { get; set; }

    public BuildingsManager()
    {
        Buildings = new List<Building>();
    }

    public void AddBuilding(Building building)
    {
        Buildings.Add(building);
    }
}
