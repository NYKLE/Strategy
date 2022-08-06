using GameInit.Builders;
using GameInit.GameCycleModule;
using UnityEngine;

namespace GameInit.Chest
{
    public class ChestCollider : ICallable
    {
        private ChestSettings _chestSettings;
        private HeroSettings _heroSettings;
        private ChestBuilder _chestBuilder;
        private ResourceManager _resourceManager;

        private float _distance;

        public ChestCollider(ChestSettings chestSettings, HeroSettings heroSettings, ChestBuilder chestBuilder, ResourceManager resourceManager)
        {
            _chestSettings = chestSettings;
            _heroSettings = heroSettings;
            _chestBuilder = chestBuilder;
            _resourceManager = resourceManager;
        }

        public void UpdateCall()
        {
            _distance = Vector3.Distance(_chestSettings.transform.position, _heroSettings.transform.position);
            if (_distance <= _chestSettings.ColliderRadius)
            {
                _resourceManager.SetResource(ResourceType.Gold, _chestSettings.GoldAmount);
                _chestBuilder.RemoveChestCollider(CycleMethod.Update, this);
               _chestSettings.gameObject.SetActive(false);
            }
        }
    }
}
