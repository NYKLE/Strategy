using GameInit.Component;
using GameInit.GameCycleModule;
using UnityEngine;

namespace GameInit.Builders
{
    public class NomadsCampBuilder
    {
        public NomadsCampBuilder(GameCycle cycle, CitizenPoolBuilder citizenPoolBuilder)
        {
            NomadsCampComponent[] nomadCamps = Object.FindObjectsOfType<NomadsCampComponent>();

            foreach (var camp in nomadCamps)
            {
                var nomadBuilder = new NomadBuilder(cycle, camp, citizenPoolBuilder);
            }
        }
    }
}
