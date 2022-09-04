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
using GameInit.ConnectBuildings;

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

       
        public UnitsAI(GameObject _prefab, NomandsComponet _nomandsComponet, GameCycle _cyrcle, Pools _CoinPool, List<IDisposable> _dispose, ConnectionsBuildings connectionsBuildings)
        {
            State = new NomandState(prefab);
            prefab = _prefab;
            
            coinInUnits = new CoinInUnits(coins, maxCoins, _CoinPool, _prefab, State, connectionsBuildings);
            _dispose.Add(coinInUnits);
            nomandsComponet = _nomandsComponet;
            _cyrcle.Add(coinInUnits);
        }
       
        public Transform getTransform()
        {
            return prefab.transform;
        }
        public void OnUpdate()
        {
           
        }
    }
}

