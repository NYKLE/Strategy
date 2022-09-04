using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.Settings;
using GamePlay.WorkShop;
using GameInit.GameCycleModule;


namespace GameInit.Builders
{
    public class BuildingsBuilder
    {
        public BuildingsBuilder(GameCycle cycle)
        {
            var prefabs = GameObject.FindObjectsOfType<WorkShopSettings>(); 
            var tools = GameObject.FindObjectOfType<ToolsPrefabs>();
            WorkShopWithHammerBuild(prefabs, tools);
        }


        private void WorkShopWithHammerBuild(WorkShopSettings[] prefabs, ToolsPrefabs tools)
        {
            foreach (var workShopSettings in prefabs)
            {
                new WorkShop(workShopSettings, workShopSettings.getType(), tools);
            }
        }
    }
}

