using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.Settings;

namespace GamePlay.WorkShop
{
    public class WorkShop
    {
        private WorkShopTypes type;
        private IWorshopState state;
        private Dictionary<WorkShopTypes, IWorshopState> statePlaceDictionary;
        private Dictionary<WorkShopTypes, IWorshopState> stateBuildDictionary;
        private WorkShopSettings workShopSettings;
        public WorkShop(WorkShopSettings _workShopSettings, WorkShopTypes _type, ToolsPrefabs tools)
        {
            type = _type;
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
            stateBuildDictionary.Add(WorkShopTypes.hammer, new WorkShopWithHammerBuild(tools));
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
