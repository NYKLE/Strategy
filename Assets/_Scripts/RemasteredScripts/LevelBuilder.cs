using UnityEngine;
using System.Collections.Generic;
using System;
using GameInit.GameCyrcleModule;
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
        private ResourceManager resourses;

        private void Awake()
        {
            var gameCycle = GetComponent<GameCycle>();
            gameCycle.Init();

            CoinPool();
            Resourses();

            CameraBuilder(gameCycle);
            HeroBuilder(gameCycle);
            ChestBuilder(gameCycle, _heroBuilder.GetHeroSettings());

            Hacks();
        }

        private void HeroBuilder(GameCycle gameCycle)
        {
            _heroBuilder = new HeroBuilder(gameCycle, _pool, resourses);
        }

        private void CameraBuilder(GameCycle gameCycle)
        {
            _cameraBuilder = new CameraBuilder(gameCycle);
        }

        private void ChestBuilder(GameCycle gameCycle, HeroSettings heroSettings)
        {
            _chestBuilder = new ChestBuilder(gameCycle, heroSettings);
        }

        private void CoinPool()
        {
            _pool = GameObject.FindObjectOfType<CoinsPool>();
            _pool.CreatPool();
        }

        private void Resourses()
        {
            resourses = new ResourceManager();
        }

        private void Hacks()
        {
            resourses.SetResource(ResourceType.Gold, 11);
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


