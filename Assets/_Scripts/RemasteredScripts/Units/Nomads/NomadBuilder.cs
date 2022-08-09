using GameInit.Component;
using GameInit.GameCycleModule;
using GameInit.Nomads;
using UnityEngine;

namespace GameInit.Builders
{
    public class NomadBuilder
    {
        public NomadBuilder(GameCycle cycle, NomadsCampComponent nomadsCampComponent, CitizenPoolBuilder citizenPoolBuilder)
        {

            NomadComponent[] nomads = new NomadComponent[nomadsCampComponent.gameObject.transform.childCount];

            for (int i = 0; i < nomadsCampComponent.gameObject.transform.childCount; i++)
            {
                nomads[i] = nomadsCampComponent.GetComponent<NomadComponent>();
            }
            

            foreach (var nomad in nomads)
            {
                NomadUpdateCycle updateCycle = new NomadUpdateCycle(nomad, nomadsCampComponent, citizenPoolBuilder);
                cycle.Add(updateCycle);
            }
        }
    }
}
