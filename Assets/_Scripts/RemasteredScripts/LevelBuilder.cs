using UnityEngine;
using System.Collections.Generic;
using System;
using GameInit.GameCyrcleModule;
using GameInit.Pool;
using GameInit.PoolPrefabs;
using GameInit.NomandCamp;
using GameInit.UnitsBuilderCreater;
using GameInit.ConnectBuildings;
using GameInit.Utility;

namespace GameInit.Builders
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(GameCyrcle))]

    public class LevelBuilder : MonoBehaviour
    {
        private readonly List<IDisposable> _dispose = new List<IDisposable>();

        private void Awake()
        {
            var GameCyrcle = GetComponent<GameCyrcle>();
            var prefabHolder = FindObjectOfType<PrefabPoolHolderComponent>(); 

            Builders(GameCyrcle, prefabHolder);
        }

        private void Builders(GameCyrcle gameCyrcle, PrefabPoolHolderComponent prefabHolder)
        {
            Pools _coinPool = new Pools(prefabHolder.GetCoinPrefab());
            
            ConnectionsBuildings connectionsBuildings = new ConnectionsBuildings(_dispose);

            NomandCamppCreater NomandCamppCreater = new NomandCamppCreater();
            UnitsBuilder UnitsBuilder = new UnitsBuilder(gameCyrcle, NomandCamppCreater, _dispose, _coinPool, connectionsBuildings);
            new BuildingsBuilder(gameCyrcle, connectionsBuildings);
            
            CameraBuilder _cameraBuilder = new CameraBuilder(gameCyrcle);
            ResourceManager _resourceManager = new ResourceManager();
            DayCycleBuilder _dayCycle = new DayCycleBuilder(gameCyrcle);

            HeroBuilder _heroBuilder = new HeroBuilder(gameCyrcle, _coinPool, _resourceManager);
            
            ChestBuilder _chestBuilder = new ChestBuilder(gameCyrcle, _heroBuilder.GetHeroSettings(), _resourceManager);

            Hacks(_resourceManager);
        }

        private void Hacks(ResourceManager _resourceManager)
        {
            _resourceManager.SetResource(ResourceType.Gold, 11);
        }

        private void OnDestroy()
        {
            foreach (var item in _dispose)
            {
                item.Dispose();
            }
        }
    }
}


