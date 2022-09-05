using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.ConnectBuildings;

namespace GamePlay.WorkShop
{
    public class WorkShopWithHammerPlace : IWorshopState
    {
        private int coinsToBuild;
        private WorkShop workShop;
        private WorkShopSettings workShopSettings;
        private ConnectionsBuildings connectionsBuildings;

        private const int needCoinsToBuild = 5;
      
        public void Enter(WorkShopSettings _workShopSettings, WorkShop _workShop)
        {
            workShop = _workShop;
            workShopSettings = _workShopSettings;
            CollisionComponent collisionComponent = workShopSettings.getPrefab().GetComponent<CollisionComponent>();
            collisionComponent.OnEnter += AddCoinsToBuild;
        }
        public void AddCoinsToBuild(Collider col)
        {
            var coin = col.gameObject.GetComponent<Coin>();
            coinsToBuild++;
            coin.Hide();
            Build();
        }

        private void Build()
        {
            if (coinsToBuild >= needCoinsToBuild)
            {
                coinsToBuild = 0;
                workShopSettings.getBuildingPlace().SetActive(false);
                workShopSettings.getBuilding().SetActive(true);
                workShop.SelectPlaceType();
            }
        }
    }
}

