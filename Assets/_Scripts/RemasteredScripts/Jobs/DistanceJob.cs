using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;

[BurstCompatible]
public struct DistanceJob : IJob
{
    [ReadOnly] public float3 ThisObjectPosition;
    [ReadOnly] public float3 TargetObjectPosition;

    [NativeDisableContainerSafetyRestriction]
    [WriteOnly]
    public NativeArray<float> Result;

    public void Execute()
    {
        Result[0] = math.distance(ThisObjectPosition, TargetObjectPosition);
    }
}
