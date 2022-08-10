using GameInit.Component;
using GameInit.GameCycleModule;
using GameInit.Pool;
using UnityEngine;

namespace GameInit.Builders
{
    public class NomadsCampBuilder
    {
        public NomadsCampBuilder(GameCycle cycle, Pools citizenPool)
        {
            NomadsCampComponent[] nomadCamps = Object.FindObjectsOfType<NomadsCampComponent>();

            foreach (var camp in nomadCamps)
            {
                var nomadBuilder = new NomadBuilder(cycle, camp, citizenPool);
            }
        }
    }
}
