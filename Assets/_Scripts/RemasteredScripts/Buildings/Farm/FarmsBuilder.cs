using GameInit.Component;
using GameInit.Farm;
using GameInit.GameCycleModule;
using GameInit.TimeCycle;
using UnityEngine;

namespace GameInit.Builders
{
    public class FarmsBuilder
    {
        public FarmsBuilder(GameCycle cycle, DayCycle dayCycle)
        {
            // /FarmComponent[] farmComponents = Object.FindObjectsOfType<FarmComponent>();
            //
            // foreach (var farmComponent in farmComponents)
            // {
            //     FarmDayCycle farmDayCycle = new FarmDayCycle(dayCycle, farmComponent);
            //
            //     cycle.Add(farmDayCycle);
            //
            // }
        }

        public void CreateFarm(GameCycle cycle, DayCycle dayCycle, FarmComponent component)
        {
            FarmDayCycle farmDayCycle = new FarmDayCycle(dayCycle, component);

            cycle.Add(farmDayCycle);
        }
    }
}
