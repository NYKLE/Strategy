using GameInit.Builders;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GameInit.Chest
{
    public class ChestCollider : IUpdate
    {
        private ChestComponent _chestComponent;
        private HeroComponent _heroComponent;
        private ChestBuilder _chestBuilder;
        private ResourceManager _resourceManager;

        // Jobs System
        private NativeArray<float> _jobResult;
        private JobHandle _jobHandle;

        // Compute Shader
        private ComputeShader _distanceComputeShader;
        private ComputeBuffer _computeBuffer;
        private readonly int _resultCS;
        private readonly int _ThisObjectPositionCS;
        private readonly int _TargetObjectPositionCS;
        private float[] _thisPositions;
        private float[] _targetPositions;
        private float[] _CSResult;

        public ChestCollider(ChestComponent chestComponent, HeroComponent heroComponent, ChestBuilder chestBuilder, ResourceManager resourceManager)
        {
            _chestComponent = chestComponent;
            _heroComponent = heroComponent;
            _chestBuilder = chestBuilder;
            _resourceManager = resourceManager;

            // Compute Shader
            _distanceComputeShader = Addressables.LoadAssetAsync<ComputeShader>("DistanceComputeShader").WaitForCompletion();
            
            _resultCS = Shader.PropertyToID("_Result");
            _ThisObjectPositionCS = Shader.PropertyToID("_ThisObjectPosition");
            _TargetObjectPositionCS = Shader.PropertyToID("_TargetObjectPosition");

            _CSResult = new float[1];
        }

        public void OnUpdate()
        {
            //CalculateDistanceByJobs();
            //CalculateDistanceByComputeShader();
            //CalculateDistanceByVector3();

            if (_chestComponent.IsCollided)
            {
                _resourceManager.SetResource(ResourceType.Gold, _chestComponent.GoldAmount);
                _chestBuilder.RemoveChestCollider(this);
                _chestComponent.gameObject.SetActive(false);
            }
        }

        private void CalculateDistanceByVector3()
        {
            if (Vector3.Distance(_chestComponent.transform.position, _heroComponent.transform.position) <=
                _chestComponent.ColliderRadius)
            {
                _resourceManager.SetResource(ResourceType.Gold, _chestComponent.GoldAmount);
                _chestBuilder.RemoveChestCollider(this);
                _chestComponent.gameObject.SetActive(false);
            }
        }

        private void CalculateDistanceByComputeShader()
        {
            _thisPositions = new[]
            {
                _chestComponent.transform.position.x,
                _chestComponent.transform.position.y,
                _chestComponent.transform.position.z
            };
            _distanceComputeShader.SetFloats(_ThisObjectPositionCS, _thisPositions);

            _targetPositions = new[]
            {
                _heroComponent.transform.position.x,
                _heroComponent.transform.position.y,
                _heroComponent.transform.position.z
            };
            _distanceComputeShader.SetFloats(_TargetObjectPositionCS, _targetPositions);

            _computeBuffer = new ComputeBuffer(1, 4);
            _distanceComputeShader.SetBuffer(0, _resultCS, _computeBuffer);

            _distanceComputeShader.Dispatch(0, 1, 1, 1);

            _computeBuffer.GetData(_CSResult);

            if (_CSResult[0] <= _chestComponent.ColliderRadius)
            {
                _resourceManager.SetResource(ResourceType.Gold, _chestComponent.GoldAmount);
                _chestBuilder.RemoveChestCollider(this);
                _chestComponent.gameObject.SetActive(false);
            }

            _computeBuffer.Release();
            _computeBuffer = null;
        }

        private void CalculateDistanceByJobs()
        {
            _jobResult = new NativeArray<float>(1, Allocator.TempJob);
            DistanceJob distanceJob = new DistanceJob()
            {
                ThisObjectPosition = _chestComponent.transform.position,
                TargetObjectPosition = _heroComponent.transform.position,
                Result = _jobResult
            };
            _jobHandle = distanceJob.Schedule();
            _jobHandle.Complete();

            if (_jobResult[0] <= _chestComponent.ColliderRadius)
            {
                _resourceManager.SetResource(ResourceType.Gold, _chestComponent.GoldAmount);
                _chestBuilder.RemoveChestCollider(this);
                _chestComponent.gameObject.SetActive(false);
            }

            _jobResult.Dispose();
        }
    }
}
