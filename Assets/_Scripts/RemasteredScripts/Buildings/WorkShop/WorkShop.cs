using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.Settings;
using GameInit.ConnectBuildings;
using GameInit.Buildings;

namespace GamePlay.WorkShop
{
    public class WorkShop
    {
        private WorkShopTypes type;
        private IWorshopstate state;
        private Dictionary<WorkShopTypes, IWorshopstate> statePlaceDictionary;
        private Dictionary<WorkShopTypes, IWorshopstate> stateBuildDictionary;
        private WorkShopSettingsComponent workShopSettingsComponent;
        private ConnectionsBuildings connectionsBuildings;
        public WorkShop(WorkShopSettingsComponent _WorkShopSettingsComponent, WorkShopTypes _type, ToolsPrefabsComponent tools, ConnectionsBuildings _connectionsBuildings)
        {
            type = _type;
            connectionsBuildings = _connectionsBuildings;
            workShopSettingsComponent = _WorkShopSettingsComponent;
            PlaceByType();
            BuildByType(tools);
            SelectPlaceType();
        }

        private void PlaceByType()
        {
            statePlaceDictionary = new Dictionary<WorkShopTypes, IWorshopstate>();
            statePlaceDictionary.Add(WorkShopTypes.hammer, new WorkShopWithHammerPlace());
        }
        private void BuildByType(ToolsPrefabsComponent tools)
        {
            stateBuildDictionary = new Dictionary<WorkShopTypes, IWorshopstate>();
            stateBuildDictionary.Add(WorkShopTypes.hammer, new WorkShopWithHammerBuild(tools, connectionsBuildings));
        }
        public void SelectPlaceType()
        {
            if (state == null || !statePlaceDictionary.ContainsValue(state))
            {
                state = statePlaceDictionary.GetValueOrDefault(type);
            }
            else
            {
                state = stateBuildDictionary.GetValueOrDefault(type);
            }
            state.Enter(workShopSettingsComponent, this);
        }

        public WorkShopTypes getType()
        {
            return type;
        }
    }

}
