using GameInit.Component;
using GameInit.GameCyrcleModule;
using GameInit.TimeCycle;
using UnityEngine;

namespace GameInit.Builders
{
    public class DayCycleBuilder
    {
        public DayCycle DayCycle { get; private set; }

        public DayCycleBuilder(GameCyrcle cycle)
        {
            var dayCycle = Object.FindObjectOfType<DayCycleComponent>();

            DayCycle = new DayCycle(dayCycle);
            cycle.Add(DayCycle);
        }
    }
}
