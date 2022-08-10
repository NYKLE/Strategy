using UnityEngine;
using System.Collections.Generic;
using System;
using GameInit.GameCycleModule;
using GameInit.Pool;
using GameInit.PoolPrefabs;

namespace GameInit.Builders
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(GameCycle))]

    public class LevelBuilder : MonoBehaviour
    {
        private readonly List<IDisposable> _dispose = new List<IDisposable>();

        private void Awake()
        {
            var gameCycle = GetComponent<GameCycle>();
            var prefabHolder = FindObjectOfType<PrefabPoolHolder>(); 

            Builders(gameCycle, prefabHolder);
        }

        private void Builders(GameCycle gameCyrcle, PrefabPoolHolder prefabHolder)
        {
             
            Pools _CoinPool = new Pools(prefabHolder.GetCoinPrefab());
            Pools _NomandPool = new Pools(prefabHolder.GetNomandPrefab());

            CitizenPoolBuilder _citizenPoolBuilder = new CitizenPoolBuilder();

            CameraBuilder _cameraBuilder = new CameraBuilder(gameCyrcle);
            ResourcesUIBuilder _resourcesUIBuilder = new ResourcesUIBuilder();
            ResourceManager _resourceManager = new ResourceManager(_resourcesUIBuilder);

            HeroBuilder _heroBuilder = new HeroBuilder(gameCyrcle, _CoinPool, _resourceManager);
            ConstructionBuilder _constructionBuilder = new ConstructionBuilder(gameCyrcle, _CoinPool);
            NomadsCampBuilder _nomadsCampBuilder = new NomadsCampBuilder(gameCyrcle, _citizenPoolBuilder);
            CitizensBuilder _citizensBuilder = new CitizensBuilder(gameCyrcle);


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


