using GameInit.GameCycleModule;
using UnityEngine;
using GameInit.PoolOfCoins;
using GameInit.DropAndCollectGold;

namespace GameInit.Builders
{
    public class HeroBuilder
    {
        private HeroComponent _heroComponent;

        public HeroBuilder(GameCycle gameCycle, CoinsPool _pool, ResourceManager resources)
        {
            var hero = Object.FindObjectOfType<Hero>();

            var transform = hero.transform;
            _heroComponent = hero.GetComponent<HeroComponent>();
            var dropCoins = new DropCoins(_pool, transform, resources, _heroComponent);
            var move = new HeroMove();

            gameCycle.Add(CycleMethod.Update, dropCoins);
        }

        public HeroComponent GetHeroSettings()
        {
            return _heroComponent;
        }
    }
}
