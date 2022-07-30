using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuilding
{
    public BuildingType Type { get; }
    public BuildingState State { get; set; }

    public int HealthMax { get; set; }
    public int HealthCurrent { get; set; }

    public int Level { get; set; }
}
