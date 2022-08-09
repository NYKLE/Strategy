using GameInit.Builders;
using GameInit.Component;
using GameInit.PoolOfCoins;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace GameInit.Construction
{
    public class ConstructionCoinCollector : IUpdate
    {
        private NativeArray<float> _result;
        private JobHandle _jobHandle;

        private CoinsPool _coinsPool;
        private ConstructionBuilder _constructionBuilder;
        private ConstructionComponent _constructionComponent;

        private NativeArray<float3> _targets;

        public ConstructionCoinCollector(CoinsPool coinPool, ConstructionBuilder constructionBuilder, ConstructionComponent constructionComponent)
        {
            _coinsPool = coinPool;
            _constructionBuilder = constructionBuilder;
            _constructionComponent = constructionComponent;
        }

        public void OnUpdate()
        {
            //CheckCollisionByJobs();

            if (_constructionComponent.GoldNeededToBuild == 0)
            {
                Debug.Log("Build Prefab");
            }
        }

        private void CheckCollisionByJobs()
        {
            _targets = new NativeArray<float3>(_coinsPool._pool.Count, Allocator.TempJob);
            for (int i = 0; i < _coinsPool._pool.Count; i++)
            {
                _targets[i] = _coinsPool._pool[i].transform.position;
            }

            _result = new NativeArray<float>(_targets.Length, Allocator.TempJob);

            DistanceJobFor distanceJob = new DistanceJobFor
            {
                ThisObjectPosition = _constructionComponent.transform.position,
                TargetObjectPosition = _targets,
                Result = _result
            };
            _jobHandle = distanceJob.Schedule(_targets.Length, 2);
            _jobHandle.Complete();

            for (int i = 0; i < _result.Length; i++)
            {
                if (_result[i] <= _constructionComponent.ColliderRadius)
                {
                    Debug.Log("Collision");
                    //_constructionBuilder.RemoveCollider(this);
                }
            }

            _targets.Dispose();
            _result.Dispose();
        }
    }
}
