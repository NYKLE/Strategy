using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.Pool;
using GameInit.Component;

namespace GameInit.Tools 
{
    public class ToolsOnMap : IUpdate
    {
        private Pools citezenPool;
        BuildingWorkshop buildingWorkshop;
        public ToolsOnMap(Pools _citezenPool, BuildingWorkshop _buildingWorkshop)
        {
            citezenPool = _citezenPool;
            buildingWorkshop = _buildingWorkshop;
        }
        public void OnUpdate()
        {
            if(buildingWorkshop.GetTools(out Dictionary<ToolType, GameObject> toolsOnMap))
            {
                foreach (var tool in toolsOnMap)
                {
                 //  var citezen = citezenPool.GetClosestEngagedElements(tool.Value.transform.position);
                  //  citezen.GetComponent<CitizenComponent>().GoesForATool(tool.Value.transform);
                }
            }
        }
    }
}


