using GamePlay.Work;
using GameInit.UnitsPrefab;
using UnityEngine;
using GamePlay.NomandsCamp;
using System;
using System.Collections.Generic;
using GameInit.Job;
using GameInit.GameCyrcleModule;
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
        private NomandsComponent nomandsComponent;
        private CoinInUnits coinInUnits;
        private IJob state;

       
        public UnitsAI(GameObject _prefab, NomandsComponent _nomandsComponent, GameCyrcle _cyrcle, Pools _coinPool, List<IDisposable> _dispose, ConnectionsBuildings connectionsBuildings)
        {
            state = new Nomandstate(prefab);
            prefab = _prefab;
            
            coinInUnits = new CoinInUnits(coins, maxCoins, _coinPool, _prefab, state, connectionsBuildings);
            _dispose.Add(coinInUnits);
            nomandsComponent = _nomandsComponent;
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

