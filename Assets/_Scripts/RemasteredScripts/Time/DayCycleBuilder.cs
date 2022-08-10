using GameInit.Component;
using GameInit.GameCycleModule;
using GameInit.TimeCycle;
using UnityEngine;

namespace GameInit.Builders
{
    public class DayCycleBuilder
    {
        public DayCycle DayCycle { get; private set; }

        public DayCycleBuilder(GameCycle cycle)
        {
            var dayCycle = Object.FindObjectOfType<DayCycleComponent>();

            DayCycle = new DayCycle(dayCycle);
            cycle.Add(DayCycle);
        }
    }
}
