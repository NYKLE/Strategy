using GameInit.Component;
using GameInit.GameCycleModule;
using GameInit.Nomads;
using GameInit.Pool;
using UnityEngine;

namespace GameInit.Builders
{
    public class NomadBuilder
    {
        public NomadBuilder(GameCycle cycle, NomadsCampComponent nomadsCampComponent, Pools citizenPool)
        {
            for (int i = 0; i < nomadsCampComponent.gameObject.transform.childCount; i++)
            {
                var nomad = nomadsCampComponent.gameObject.transform.GetChild(i).GetComponent<NomadComponent>();
                NomadUpdateCycle updateCycle = new NomadUpdateCycle(cycle, nomad, nomadsCampComponent, citizenPool);
                cycle.Add(updateCycle);
            }
        }
    }
}
