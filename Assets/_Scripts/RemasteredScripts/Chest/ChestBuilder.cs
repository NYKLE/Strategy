using GameInit.Chest;
using GameInit.GameCycleModule;
using UnityEngine;

namespace GameInit.Builders
{
    public class ChestBuilder
    {
        private GameCycle _cycle;
        private HeroComponent _heroComponent;
        private ResourceManager _resourceManager;
        private ChestComponent[] _chestSettings;

        public ChestBuilder(GameCycle cycle, HeroComponent heroComponent, ResourceManager resourceManager)
        {
            _cycle = cycle;
            _heroComponent = heroComponent;
            _resourceManager = resourceManager;

            _chestSettings = Object.FindObjectsOfType<ChestComponent>();

            foreach (var settings in _chestSettings)
            {
                ChestCollider chestCollider = new ChestCollider(settings, _heroComponent, this, _resourceManager);

                cycle.Add(chestCollider);
            }
        }

        public void RemoveChestCollider(IUpdate update)
        {
            _cycle.Remove(update);
        }
    }
}
