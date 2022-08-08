using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;

[BurstCompatible]
public struct DistanceJobFor : IJobParallelFor
{
    [ReadOnly] public float3 ThisObjectPosition;
    [ReadOnly] public NativeArray<float3> TargetObjectPosition;

    [NativeDisableContainerSafetyRestriction]
    [WriteOnly]
    public NativeArray<float> Result;

    public void Execute(int index)
    {
        Result[index] = math.distance(ThisObjectPosition, TargetObjectPosition[index]);
    }
}