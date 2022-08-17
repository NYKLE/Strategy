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
    public class UnitsAI : IDisposable, IUpdate
    {
        private int coins;
        private int maxCoins = 5;

        private GameObject prefab;
        private NomandsComponet nomandsComponet;
        private CollisionComponent collision;
        private CoinInUnits coinInUnits;
        private IJob State;
        
        
        private event Action collectCoin;
        public UnitsAI(GameObject _prefab, NomandsComponet _nomandsComponet, GameCycle _cyrcle, Pools _CoinPool)
        {
            State = new NomandState();
            prefab = _prefab;
            collision = _prefab.GetComponent<CollisionComponent>();
            coinInUnits = new CoinInUnits(collision, coins, maxCoins, _CoinPool, _prefab, State);
            ActionAdd();
            collision.AddAction(collectCoin);
            nomandsComponet = _nomandsComponet;
            _cyrcle.Add(coinInUnits);
        }
       
        private void ActionAdd()
        {
            collectCoin += coinInUnits.AddCoin;
        }
        public void Dispose()
        {
            collectCoin -= coinInUnits.AddCoin;
        }

        public void OnUpdate()
        {
           
        }
    }
}

