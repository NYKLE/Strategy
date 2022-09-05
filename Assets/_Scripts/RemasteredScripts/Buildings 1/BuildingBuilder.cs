using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.Settings;
using GamePlay.WorkShop;
using GameInit.GameCycleModule;
using GameInit.ConnectBuildings;


namespace GameInit.Builders
{
    public class BuildingsBuilder
    {
        public BuildingsBuilder(GameCycle cycle, ConnectionsBuildings connectionsBuildings)
        {
            var prefabs = GameObject.FindObjectsOfType<WorkShopSettings>(); 
            var tools = GameObject.FindObjectOfType<ToolsPrefabs>();
            WorkShopWithHammerBuild(prefabs, tools, connectionsBuildings);
        }


        private void WorkShopWithHammerBuild(WorkShopSettings[] prefabs, ToolsPrefabs tools, ConnectionsBuildings connectionsBuildings)
        {
            foreach (var workShopSettings in prefabs)
            {
                new WorkShop(workShopSettings, workShopSettings.getType(), tools, connectionsBuildings);
            }
        }
    }
}

