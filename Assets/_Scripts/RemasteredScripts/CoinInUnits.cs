using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.Pool;
using System;
using UnityEngine.AI;
using GameInit.Job;


namespace GamePlay.CoinsInUnits
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CoinInUnits : IUpdate
    {
        public bool IsGoingForACoin { get; private set; }
        
        private CollisionComponent collisionComponent;
        private int coins;
        private int maxCoins;
        private Pools CoinPool;
        private GameObject prefab;
        private NavMeshAgent navMesh;
        private IJob State;
        public CoinInUnits(CollisionComponent _collisionComponent, int _coins, int _maxCoins, Pools _CoinPool, GameObject _prefab, IJob _State)
        {
            State = _State;
            prefab = _prefab;
            navMesh = prefab.GetComponent<NavMeshAgent>();
            CoinPool = _CoinPool;
            collisionComponent = _collisionComponent;
            coins = _coins;
            maxCoins = _maxCoins;
        }

        private GameObject CheckIfThereIsAnyCoinClose()
        {
            var coins = CoinPool.GetEngagedElements();
            if(coins != null)
            {
                foreach (var coin in coins)
                {
                    Vector3 difference = new Vector3(
                    coin.transform.position.x - prefab.transform.position.x,
                    coin.transform.position.y - prefab.transform.position.y,
                    coin.transform.position.z - prefab.transform.position.z);

                    double distance = Math.Sqrt(
                    Math.Pow(difference.x, 2d) +
                    Math.Pow(difference.y, 2d) +
                    Math.Pow(difference.z, 2d));

                    if (distance < 12d)
                    {
                        return coin;
                    }
                }
            }
           return null;
        }

        private void FindTheWay(GameObject coin)
        {
            if (coin != null && coin.activeInHierarchy)
            {
                navMesh.SetDestination(coin.transform.position);
            }
        }
        public void DropCoin()
        {
            if (coins > 0)
            {
                coins--;
            }
        }
        public void AddCoin()
        {
            coins++;
            if(coins == 1)
            {
                State = new CitizenState();
            }
        }
        public void OnUpdate()
        {
            if(coins <= maxCoins)
            FindTheWay(CheckIfThereIsAnyCoinClose());
        }
    }
}

