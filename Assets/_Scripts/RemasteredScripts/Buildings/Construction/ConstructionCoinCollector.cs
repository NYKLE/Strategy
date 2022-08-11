using GameInit.Builders;
using GameInit.Component;
using GameInit.Pool;
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

        private Pools _Pools;
        private ConstructionBuilder _constructionBuilder;
        private ConstructionComponent _constructionComponent;

        private NativeArray<float3> _targets;

        public ConstructionCoinCollector(Pools coinPool, ConstructionBuilder constructionBuilder, ConstructionComponent constructionComponent)
        {
            _Pools = coinPool;
            _constructionBuilder = constructionBuilder;
            _constructionComponent = constructionComponent;
        }

        public void OnUpdate()
        {
            //CheckCollisionByJobs();

            if (_constructionComponent.GoldNeededToBuild == 0)
            {
                // Building
            }
        }

        private void CheckCollisionByJobs()
        {
            _targets = new NativeArray<float3>(_Pools._pool.Count, Allocator.TempJob);
            for (int i = 0; i < _Pools._pool.Count; i++)
            {
                _targets[i] = _Pools._pool[i].transform.position;
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
