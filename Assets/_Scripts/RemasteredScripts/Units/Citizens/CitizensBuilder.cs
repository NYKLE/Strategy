using GameInit.Citizen;
using GameInit.Component;
using GameInit.GameCycleModule;
using GameInit.Pool;
using UnityEngine;

namespace GameInit.Builders
{
    public class CitizensBuilder
    {
        public CitizensBuilder(GameCycle cycle, Pools pool)
        {
            foreach (var citizen in pool._pool)
            {
                
                 CitizenComponent citizenComponent = citizen.GetComponent<CitizenComponent>();
                var citizenCoinPicker = new CitizenCoinPicker(citizenComponent, pool);
                cycle.Add(citizenCoinPicker);
            }
        }
    }
}
