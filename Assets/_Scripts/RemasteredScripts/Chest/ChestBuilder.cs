using System.Collections.Generic;
using GameInit.Chest;
using GameInit.GameCycleModule;
using UnityEngine;

namespace GameInit.Builders
{
    public class ChestBuilder
    {
        public List<ChestCollider> Colliders { get; }

        private GameCycle _cycle;
        private HeroSettings _heroSettings;
        private ResourceManager _resourceManager;
        private ResourcesUIBuilder _resourcesUIBuilder;

        public ChestBuilder(GameCycle cycle, HeroSettings heroSettings, ResourceManager resourceManager, ResourcesUIBuilder resourcesUIBuilder)
        {
            _cycle = cycle;
            _heroSettings = heroSettings;
            _resourceManager = resourceManager;
            _resourcesUIBuilder = resourcesUIBuilder;

            Colliders = new List<ChestCollider>();
            ChestSettings[] chestSettings = Object.FindObjectsOfType<ChestSettings>();

            foreach (var settings in chestSettings)
            {
                var chestCollider = new ChestCollider(settings, _heroSettings, this, _resourceManager);
                Colliders.Add(chestCollider);

                cycle.Add(CycleMethod.Update, chestCollider);
            }
        }

        public void RemoveChestCollider(CycleMethod method, ICallable callable)
        {
            _cycle.Remove(method, callable);
        }
    }
}
