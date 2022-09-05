using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.Settings;
using GamePlay.WorkShop;
using GameInit.GameCyrcleModule;
using GameInit.ConnectBuildings;


namespace GameInit.Builders
{
    public class BuildingsBuilder
    {
        public BuildingsBuilder(GameCyrcle cycle, ConnectionsBuildings connectionsBuildings)
        {
            var prefabs = GameObject.FindObjectsOfType<WorkShopSettingsComponent>(); 
            var tools = GameObject.FindObjectOfType<ToolsPrefabsComponent>();
            WorkShopWithHammerBuild(prefabs, tools, connectionsBuildings);
        }


        private void WorkShopWithHammerBuild(WorkShopSettingsComponent[] prefabs, ToolsPrefabsComponent tools, ConnectionsBuildings connectionsBuildings)
        {
            foreach (var workShopSettingsComponent in prefabs)
            {
                new WorkShop(workShopSettingsComponent, workShopSettingsComponent.getType(), tools, connectionsBuildings);
            }
        }
    }
}

