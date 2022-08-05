using GameInit.GameCyrcleModule;
using UnityEngine;

namespace GameInit.Builders
{
    public class HeroBuilder
    {
        private HeroSettings _heroSettings;

        public HeroBuilder(GameCycle gameCycle)
        {
            var hero = Object.FindObjectOfType<Hero>();

            var transform = hero.transform;
            _heroSettings = hero.GetComponent<HeroSettings>();
            var move = new HeroMove();

            //gameCycle.Add(CycleMethod.Update, move);

        }

        public HeroSettings GetHeroSettings()
        {
            return _heroSettings;
        }
    }
}
