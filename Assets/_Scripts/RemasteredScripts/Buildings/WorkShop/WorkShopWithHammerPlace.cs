using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.ConnectBuildings;

namespace GamePlay.WorkShop
{
    public class WorkShopWithHammerPlace : IWorshopstate
    {
        private int coinsToBuild;
        private WorkShop workShop;
        private WorkShopSettingsComponent workShopSettingsComponent;
        
        private const int needCoinsToBuild = 5;
      
        public void Enter(WorkShopSettingsComponent _WorkShopSettingsComponent, WorkShop _workShop)
        {
            workShop = _workShop;
            workShopSettingsComponent = _WorkShopSettingsComponent;
            CollisionComponent collisionComponent = workShopSettingsComponent.getPrefab().GetComponent<CollisionComponent>();
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
                workShopSettingsComponent.getBuildingPlace().SetActive(false);
                workShopSettingsComponent.getBuilding().SetActive(true);
                workShop.SelectPlaceType();
            }
        }
    }
}

