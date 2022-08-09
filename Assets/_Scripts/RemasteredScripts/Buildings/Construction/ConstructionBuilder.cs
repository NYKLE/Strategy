using GameInit.Component;
using GameInit.Construction;
using GameInit.GameCycleModule;
using GameInit.Pool;
using UnityEngine;

namespace GameInit.Builders
{
    public class ConstructionBuilder
    {
        private ConstructionComponent[] _constructionComponent;
        private GameCycle _cycle;

        public ConstructionBuilder(GameCycle cycle, Pools coinPool)
        {
            _constructionComponent = Object.FindObjectsOfType<ConstructionComponent>();

            foreach (var constructionComponent in _constructionComponent)
            {
                ConstructionCoinCollector constructionCoinCollector = new ConstructionCoinCollector(coinPool, this, constructionComponent);
                cycle.Add(constructionCoinCollector);
            }
        }

        public void RemoveCollider(IUpdate update)
        {
            _cycle.Remove(update);
        }
    }
}
