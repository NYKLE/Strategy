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
        private ChestSettings[] _chestSettings;

        public ChestBuilder(GameCycle cycle, HeroSettings heroSettings, ResourceManager resourceManager)
        {
            _cycle = cycle;
            _heroSettings = heroSettings;
            _resourceManager = resourceManager;

            _chestSettings = Object.FindObjectsOfType<ChestSettings>();

            Colliders = new List<ChestCollider>(_chestSettings.Length);

            foreach (var settings in _chestSettings)
            {
                var chestCollider = new ChestCollider(settings, _heroSettings, this, _resourceManager);
                Colliders.Add(chestCollider);

                //cycle.Add(CycleMethod.Update, chestCollider);
                cycle.Add((IUpdate)chestCollider);
            }
        }

        public void RemoveChestCollider(CycleMethod method, ICallable callable)
        {
            _cycle.Remove(method, callable);
        }

        public void RemoveChestCollider(IUpdate update)
        {
            _cycle.Remove(update);
        }
    }
}
