using UnityEngine;
using GameInit.PoolOfCoins;
using GameInit.GameCyrcleModule;
using System.Threading.Tasks;
using System;

namespace GameInit.DropAndCollectGold
{
    public class DropCoins : ICallable
    {
        private CoinsPool pool;
        private Transform transform;
        private ResourceManager resourses;
        HeroSettings heroSettings;
        public DropCoins(CoinsPool _pool, Transform _transform, ResourceManager _resourses, HeroSettings _heroSettings)
        {
            pool = _pool;
            transform = _transform;
            resourses = _resourses;
            heroSettings = _heroSettings;
        }

        public void UpdateCall()
        {
            if (Input.GetKeyDown(KeyCode.Space) && resourses.GetResource(ResourceType.Gold) != 0)
            {
                DropCoin();
            }
            CollectGold();
        }

        private async void DropCoin()
        {
            await Task.Delay(TimeSpan.FromSeconds(0.2f));
            pool.GetFreeElements(transform.position);
            resourses.SetResource(ResourceType.Gold, -1);
        }
        private void CollectGold()
        {
            if(heroSettings.GetCoin() != null && heroSettings.GetCoin().CanPickUp)
            {
                heroSettings.GetCoin().Hide();
                resourses.SetResource(ResourceType.Gold, 1);
            }
        }
    }
}


