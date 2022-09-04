using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.WorkShop
{
    public class WorkShopWithHammerBuild : IWorshopState
    {
        private ToolsPrefabs tools;
        private int curCoins;
        private WorkShopSettings workShopSettings;

        private const int needCoinsToBuild = 2;
        public WorkShopWithHammerBuild(ToolsPrefabs _tools) { tools = _tools; }
        public void Enter(WorkShopSettings _workShopSettings, WorkShop workShop)
        {
            workShopSettings = _workShopSettings;
            CollisionComponent collisionComponent = workShopSettings.getPrefab().GetComponent<CollisionComponent>();
            collisionComponent.OnEnter += AddCoinsToBuild;
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
                MonoBehaviour.Instantiate(tools.getDictionary().GetValueOrDefault(WorkShopTools.hammers), workShopSettings.getSpawnPoint(), Quaternion.identity);
            }
        }
    }
}
