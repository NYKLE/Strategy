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
        private Pools CoinPool;
        private GameObject prefab;
        private NavMeshAgent navMesh;
        private IJob State;
        private ConnectionsBuildings connectionsBuildings;
        public CoinInUnits(int _coins, int _maxCoins, Pools _CoinPool, GameObject _prefab, IJob _State, ConnectionsBuildings _connectionsBuildings)
        {
            connectionsBuildings = _connectionsBuildings;
            State = _State;
            prefab = _prefab;
            navMesh = prefab.GetComponent<NavMeshAgent>();
            CoinPool = _CoinPool;
            collisionComponent = _prefab.GetComponent<CollisionComponent>();
            collisionComponent.OnEnter += AddCoin;
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
                        difference.x * 2 +
                        difference.y * 2 +
                        difference.z * 2);

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
                var citizen = new CitizenState(prefab, navMesh);
                State = citizen;
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

