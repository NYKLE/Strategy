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
        private CoinsPool _coinsPool;
        private ResourceManager _resourceManager;
        private ResourcesUIBuilder _resourcesUIBuilder;
        private ConstructionBuilder _constructionBuilder;

        private void Awake()
        {
            var gameCycle = GetComponent<GameCycle>();
            gameCycle.Init();

            CoinPool();
            Resources();

            CameraBuilder(gameCycle);
            HeroBuilder(gameCycle);
            ChestBuilder(gameCycle, _heroBuilder.GetHeroSettings());
            ConstructionBuilder(gameCycle);

            Hacks();
        }

        private void ConstructionBuilder(GameCycle cycle)
        {
            _constructionBuilder = new ConstructionBuilder(cycle, _coinsPool);
        }

        private void HeroBuilder(GameCycle gameCycle)
        {
            _heroBuilder = new HeroBuilder(gameCycle, _coinsPool, _resourceManager);
        }

        private void CameraBuilder(GameCycle gameCycle)
        {
            _cameraBuilder = new CameraBuilder(gameCycle);
        }

        private void ChestBuilder(GameCycle gameCycle, HeroComponent heroComponent)
        {
            _chestBuilder = new ChestBuilder(gameCycle, heroComponent, _resourceManager);
        }

        private void CoinPool()
        {
            _coinsPool = GameObject.FindObjectOfType<CoinsPool>();
            _coinsPool.CreatePool();
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


