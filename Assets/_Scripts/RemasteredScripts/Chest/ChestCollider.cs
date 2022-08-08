using GameInit.Builders;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GameInit.Chest
{
    public class ChestCollider : IUpdate
    {
        private ChestSettings _chestSettings;
        private HeroSettings _heroSettings;
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

        public ChestCollider(ChestSettings chestSettings, HeroSettings heroSettings, ChestBuilder chestBuilder, ResourceManager resourceManager)
        {
            _chestSettings = chestSettings;
            _heroSettings = heroSettings;
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
            CalculateDistanceByComputeShader();
        }

        private void CalculateDistanceByComputeShader()
        {
            _thisPositions = new[]
            {
                _chestSettings.transform.position.x,
                _chestSettings.transform.position.y,
                _chestSettings.transform.position.z
            };
            _distanceComputeShader.SetFloats(_ThisObjectPositionCS, _thisPositions);

            _targetPositions = new[]
            {
                _heroSettings.transform.position.x,
                _heroSettings.transform.position.y,
                _heroSettings.transform.position.z
            };
            _distanceComputeShader.SetFloats(_TargetObjectPositionCS, _targetPositions);

            _computeBuffer = new ComputeBuffer(1, 4);
            _distanceComputeShader.SetBuffer(0, _resultCS, _computeBuffer);

            _distanceComputeShader.Dispatch(0, 1, 1, 1);

            _computeBuffer.GetData(_CSResult);

            if (_CSResult[0] <= _chestSettings.ColliderRadius)
            {
                _resourceManager.SetResource(ResourceType.Gold, _chestSettings.GoldAmount);
                _chestBuilder.RemoveChestCollider(this);
                _chestSettings.gameObject.SetActive(false);
            }

            _computeBuffer.Release();
            _computeBuffer = null;
        }

        private void CalculateDistanceByJobs()
        {
            _jobResult = new NativeArray<float>(1, Allocator.TempJob);
            DistanceJob distanceJob = new DistanceJob()
            {
                ThisObjectPosition = _chestSettings.transform.position,
                TargetObjectPosition = _heroSettings.transform.position,
                Result = _jobResult
            };
            _jobHandle = distanceJob.Schedule();
            _jobHandle.Complete();

            if (_jobResult[0] <= _chestSettings.ColliderRadius)
            {
                _resourceManager.SetResource(ResourceType.Gold, _chestSettings.GoldAmount);
                _chestBuilder.RemoveChestCollider(this);
                _chestSettings.gameObject.SetActive(false);
            }

            _jobResult.Dispose();
        }
    }
}
