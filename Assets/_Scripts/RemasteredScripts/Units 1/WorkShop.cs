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
        private IWorshopState state;
        private Dictionary<WorkShopTypes, IWorshopState> statePlaceDictionary;
        private Dictionary<WorkShopTypes, IWorshopState> stateBuildDictionary;
        private WorkShopSettings workShopSettings;
        private ConnectionsBuildings connectionsBuildings;
        public WorkShop(WorkShopSettings _workShopSettings, WorkShopTypes _type, ToolsPrefabs tools, ConnectionsBuildings _connectionsBuildings)
        {
            type = _type;
            connectionsBuildings = _connectionsBuildings;
            workShopSettings = _workShopSettings;
            PlaceByType();
            BuildByType(tools);
            SelectPlaceType();
        }

        private void PlaceByType()
        {
            statePlaceDictionary = new Dictionary<WorkShopTypes, IWorshopState>();
            statePlaceDictionary.Add(WorkShopTypes.hammer, new WorkShopWithHammerPlace());
        }
        private void BuildByType(ToolsPrefabs tools)
        {
            stateBuildDictionary = new Dictionary<WorkShopTypes, IWorshopState>();
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
            state.Enter(workShopSettings, this);
        }

        public WorkShopTypes getType()
        {
            return type;
        }
    }

}
