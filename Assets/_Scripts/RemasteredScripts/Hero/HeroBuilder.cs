using GameInit.GameCyrcleModule;
using UnityEngine;
using GameInit.PoolOfCoins;
using GameInit.DropAndCollectGold;

namespace GameInit.Builders
{
    public class HeroBuilder
    {
        private HeroSettings _heroSettings;

        public HeroBuilder(GameCycle gameCycle, CoinsPool _pool, ResourceManager resourses)
        {
            var hero = Object.FindObjectOfType<Hero>();

            var transform = hero.transform;
            _heroSettings = hero.GetComponent<HeroSettings>();
            var dropCoins = new DropCoins(_pool, transform, resourses, _heroSettings);
            var move = new HeroMove();

            gameCycle.Add(CycleMethod.Update, dropCoins);

        }

        public HeroSettings GetHeroSettings()
        {
            return _heroSettings;
        }
    }
}
