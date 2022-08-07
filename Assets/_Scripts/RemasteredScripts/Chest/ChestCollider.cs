using GameInit.Builders;
using GameInit.GameCycleModule;
using Unity.Collections;
using Unity.Jobs;

namespace GameInit.Chest
{
    public class ChestCollider : ICallable
    {
        private ChestSettings _chestSettings;
        private HeroSettings _heroSettings;
        private ChestBuilder _chestBuilder;
        private ResourceManager _resourceManager;

        private NativeArray<float> _result;
        private JobHandle _jobHandle;

        public ChestCollider(ChestSettings chestSettings, HeroSettings heroSettings, ChestBuilder chestBuilder, ResourceManager resourceManager)
        {
            _chestSettings = chestSettings;
            _heroSettings = heroSettings;
            _chestBuilder = chestBuilder;
            _resourceManager = resourceManager;
        }

        public void UpdateCall()
        {
            _result = new NativeArray<float>(1, Allocator.TempJob);
            DistanceJob distanceJob = new DistanceJob()
            {
                chestPos = _chestSettings.transform.position,
                heroPos = _heroSettings.transform.position,
                result = _result
            };
            _jobHandle = distanceJob.Schedule();
            _jobHandle.Complete();

            if (_result[0] <= _chestSettings.ColliderRadius)
            {
                _resourceManager.SetResource(ResourceType.Gold, _chestSettings.GoldAmount);
                _chestBuilder.RemoveChestCollider(CycleMethod.Update, this);
                _chestSettings.gameObject.SetActive(false);
            }

            _result.Dispose();
        }

        public void LateUpdateCall()
        {
            
        }
    }
}