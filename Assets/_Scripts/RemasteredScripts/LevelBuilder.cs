using UnityEngine;
using System.Collections.Generic;
using System;
using GameInit.GameCyrcleModule;

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

        private void Awake()
        {
            var gameCycle = GetComponent<GameCycle>();
            gameCycle.Init();

            CameraBuilder(gameCycle);
            HeroBuilder(gameCycle);
            ChestBuilder(gameCycle, _heroBuilder.GetHeroSettings());
        }

        private void HeroBuilder(GameCycle gameCycle)
        {
            _heroBuilder = new HeroBuilder(gameCycle);
        }

        private void CameraBuilder(GameCycle gameCycle)
        {
            _cameraBuilder = new CameraBuilder(gameCycle);
        }

        private void ChestBuilder(GameCycle gameCycle, HeroSettings heroSettings)
        {
            _chestBuilder = new ChestBuilder(gameCycle, heroSettings);
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


