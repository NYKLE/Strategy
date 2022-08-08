using GameInit.Component;
using GameInit.Construction;
using GameInit.GameCycleModule;
using GameInit.PoolOfCoins;
using UnityEngine;

namespace GameInit.Builders
{
    public class ConstructionBuilder
    {
        private ConstructionComponent[] _constructionComponent;
        private GameCycle _cycle;

        public ConstructionBuilder(GameCycle cycle, CoinsPool coinPool)
        {
            _constructionComponent = Object.FindObjectsOfType<ConstructionComponent>();

            foreach (var constructionComponent in _constructionComponent)
            {
                ConstructionCollider constructionCollider = new ConstructionCollider(coinPool, this, constructionComponent);
                cycle.Add(constructionCollider);
            }
        }

        public void RemoveCollider(IUpdate update)
        {
            _cycle.Remove(update);
        }
    }
}
