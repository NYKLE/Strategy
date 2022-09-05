using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.Pool;
using System;
using UnityEngine.AI;
using GameInit.Job;
using GameInit.ConnectBuildings;


namespace GamePlay.CoinsInUnits
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CoinInUnits : IUpdate, IDisposable
    {
        public bool IsGoingForACoin { get; private set; }
        
        private CollisionComponent collisionComponent;
        private int coins;
        private int maxCoins;
        private Pools coinPool;
        private GameObject prefab;
        private NavMeshAgent navMesh;
        private IJob state;
        private ConnectionsBuildings connectionsBuildings;
        public CoinInUnits(int _coins, int _maxCoins, Pools _coinPool, GameObject _prefab, IJob _state, ConnectionsBuildings _connectionsBuildings)
        {
            connectionsBuildings = _connectionsBuildings;
            state = _state;
            prefab = _prefab;
            navMesh = prefab.GetComponent<NavMeshAgent>();
            coinPool = _coinPool;
            collisionComponent = _prefab.GetComponent<CollisionComponent>();
            collisionComponent.OnEnter += AddCoin;
            coins = _coins;
            maxCoins = _maxCoins;
        }

        private GameObject CheckIfThereIsAnyCoinClose()
        {
            var coins = coinPool.GetEngagedElements();
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
        public void AddCoin(Collider col)
        {
            coins++;
            col.gameObject.GetComponent<Coin>().Hide();
            if (coins == 1)
            {
                var citizen = new Citizenstate(prefab, navMesh);
                state = citizen;
                connectionsBuildings.getConnectionsWorkShop().addUnits(citizen);
            }
        }
        public void OnUpdate()
        {
            if(coins <= maxCoins)
            FindTheWay(CheckIfThereIsAnyCoinClose());
        }

        public void Dispose()
        {
            collisionComponent.OnEnter -= AddCoin;
        }
    }
}

