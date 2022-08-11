using GameInit.GameCycleModule;
using GameInit.Pool;
using GameInit.Tools;
using UnityEngine;

namespace GameInit.Builders
{
    public class ToolsBuilder
    {
        public ToolsBuilder(GameCycle cycle, Pools citezenPool)
        {
            BuildingWorkshop buildingWorkshop = Object.FindObjectOfType<BuildingWorkshop>();
            ToolsOnMap toolsOnMap = new ToolsOnMap(citezenPool, buildingWorkshop);


            cycle.Add(toolsOnMap);

        }
    }
}

