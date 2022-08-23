using GamePlay.Work;
using GameInit.UnitsPrefab;
using UnityEngine;
using GamePlay.NomandsCamp;
using System;
using System.Collections.Generic;
using GameInit.Job;
using GameInit.GameCycleModule;
using GamePlay.CoinsInUnits;
using GameInit.Pool;

namespace GamePlay.Units
{
    public class UnitsAI : IUpdate
    {
        private int coins;
        private int maxCoins = 5;

        private GameObject prefab;
        private NomandsComponet nomandsComponet;
        private CoinInUnits coinInUnits;
        private IJob State;

       
        private event Action collectCoin;
        public UnitsAI(GameObject _prefab, NomandsComponet _nomandsComponet, GameCycle _cyrcle, Pools _CoinPool, List<IDisposable> _dispose)
        {
            State = new NomandState();
            prefab = _prefab;
            
            coinInUnits = new CoinInUnits(coins, maxCoins, _CoinPool, _prefab, State);
            _dispose.Add(coinInUnits);
            nomandsComponet = _nomandsComponet;
            _cyrcle.Add(coinInUnits);
        }
       
        public void OnUpdate()
        {
           
        }
    }
}

