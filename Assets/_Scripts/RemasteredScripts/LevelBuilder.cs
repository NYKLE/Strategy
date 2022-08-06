using UnityEngine;
using System.Collections.Generic;
using System;
using GameInit.GameCycleModule;
using GameInit.PoolOfCoins;

namespace GameInit.Builders
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(GameCycle))]

    public class LevelBuilder : MonoBehaviour
    {
        private readonly List<IDisposable> _dispose = new List<IDisposable>();

        private HeroBuilder _heroBuilder;
        private CameraBuilder _cameraBuilder;
        private ChestBuilder _chestBuilder;
        private CoinsPool _pool;
        private ResourceManager _resourceManager;
        private ResourcesUIBuilder _resourcesUIBuilder;


        private void Awake()
        {
            var gameCycle = GetComponent<GameCycle>();
            gameCycle.Init();

            CoinPool();
            Resources();

            CameraBuilder(gameCycle);
            HeroBuilder(gameCycle);
            ChestBuilder(gameCycle, _heroBuilder.GetHeroSettings());

            Hacks();
        }

        private void HeroBuilder(GameCycle gameCycle)
        {
            _heroBuilder = new HeroBuilder(gameCycle, _pool, _resourceManager);
        }

        private void CameraBuilder(GameCycle gameCycle)
        {
            _cameraBuilder = new CameraBuilder(gameCycle);
        }

        private void ChestBuilder(GameCycle gameCycle, HeroSettings heroSettings)
        {
            _chestBuilder = new ChestBuilder(gameCycle, heroSettings, _resourceManager, _resourcesUIBuilder);
        }

        private void CoinPool()
        {
            _pool = GameObject.FindObjectOfType<CoinsPool>();
            _pool.CreatPool();
        }

        private void ResourcesUIBuilder()
        {
            _resourcesUIBuilder = new ResourcesUIBuilder();
        }

        private void Resources()
        {
            ResourcesUIBuilder();
            _resourceManager = new ResourceManager(_resourcesUIBuilder);
        }

        private void Hacks()
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


