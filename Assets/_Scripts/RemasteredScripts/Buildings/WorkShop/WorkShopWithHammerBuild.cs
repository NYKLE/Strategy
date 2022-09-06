using GameInit.Buildings;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.ConnectBuildings;

namespace GamePlay.WorkShop
{
    public class WorkShopWithHammerBuild : IWorshopstate, IBuildings
    {
        private ToolsPrefabsComponent tools;
        private int curCoins;
        private WorkShopSettingsComponent workShopSettingsComponent;
        private ConnectionsBuildings connectionsBuildings;

        private const int needCoinsToBuild = 2;

        public Action<Transform> sendTransform { get; set; } = (transform) => { };

        public WorkShopWithHammerBuild(ToolsPrefabsComponent _tools, ConnectionsBuildings _connectionsBuildings) { tools = _tools; connectionsBuildings = _connectionsBuildings; }
        public void Enter(WorkShopSettingsComponent _WorkShopSettingsComponent, WorkShop workShop)
        {
            workShopSettingsComponent = _WorkShopSettingsComponent;
            CollisionComponent collisionComponent = workShopSettingsComponent.getPrefab().GetComponent<CollisionComponent>();
            collisionComponent.OnEnter += AddCoinsToBuild;
            connectionsBuildings.getConnectionsWorkShop().addWorkshops(this);
        }
        public void AddCoinsToBuild(Collider col)
        {
            var coin = col.gameObject.GetComponent<Coin>();
            if(curCoins < needCoinsToBuild)
            {
                curCoins++;
                coin.Hide();
            }
            SpawnTool();
        }

        private void SpawnTool()
        {
            if (curCoins >= needCoinsToBuild)
            {
                curCoins = 0;
                var tool = MonoBehaviour.Instantiate(tools.getDictionary().GetValueOrDefault(WorkShopTools.hammers), workShopSettingsComponent.getSpawnPoint(), Quaternion.identity);
                sendTransform.Invoke(tool.transform);
            }
        }
    }
}
