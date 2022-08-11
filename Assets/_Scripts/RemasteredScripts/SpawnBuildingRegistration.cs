using System;
using System.Collections.Generic;
using GameInit.GameCycleModule;
using UnityEngine;

namespace GameInit.Utility
{
    public class SpawnBuildingRegistration
    {
        public Dictionary<BuildingType, List<GameObject>> Buildings { get; private set; }

        public SpawnBuildingRegistration(GameCycle cycle)
        {
            Buildings = new Dictionary<BuildingType, List<GameObject>>(16);
            foreach (BuildingType type in Enum.GetValues(typeof(BuildingType)))
            {
                Buildings.Add(type, new List<GameObject>(64));
            }
        }

        public void Add(BuildingType type, GameObject building)
        {
            Buildings[type].Add(building);
        }

        public void Remove(BuildingType type, GameObject building)
        {
            Buildings[type].Remove(building);
        }
    }
}
