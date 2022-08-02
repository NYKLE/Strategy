using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingsManager
{
    public List<BuildingBase> Buildings { get; set; }

    public BuildingsManager()
    {
        Buildings = new List<BuildingBase>();
    }

    public void AddBuilding(BuildingBase buildingBase)
    {
        Buildings.Add(buildingBase);
    }

    public void RemoveBuilding(BuildingBase buildingBase)
    {
        Buildings.Remove(buildingBase);
    }
}
