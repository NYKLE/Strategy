using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Building : IBuilding
{
    public BuildingType Type { get; }
    public BuildingState State { get; set; }
    public int HealthMax { get; set; }
    public int HealthCurrent { get; set; }
    public int Level { get; set; }

    private float _multiplier = 1.25f;

    public Building(BuildingType type)
    {
        Type = type;
        State = BuildingState.Full;
        Level = 1;
    }

    public void Upgrade()
    {
        if (Level < 3 && State == BuildingState.Full)
        {
            Level++;
            int newHealthMax = (int)(HealthMax * _multiplier);
            HealthMax = newHealthMax;
            HealthCurrent = newHealthMax;
        }
    }
}
