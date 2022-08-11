using GameInit.Component;
using GameInit.Construction;
using GameInit.GameCycleModule;
using GameInit.Pool;
using GameInit.Utility;
using UnityEngine;

namespace GameInit.Builders
{
    public class ConstructionBuilder
    {
        private ConstructionComponent[] _constructionComponent;

        public ConstructionBuilder(GameCycle cycle, Pools coinPool, SpawnBuildingRegistration registration)
        {
            _constructionComponent = Object.FindObjectsOfType<ConstructionComponent>();

            foreach (var constructionComponent in _constructionComponent)
            {
                ConstructionCoinCollector constructionCoinCollector = new ConstructionCoinCollector(coinPool, this, constructionComponent);
                ConstructionFinishBuilding finishBuilding = new ConstructionFinishBuilding(cycle, constructionComponent, registration);

                cycle.Add(constructionCoinCollector);
                cycle.Add(finishBuilding);
            }
        }
    }
}
