using GameInit.Component;
using GameInit.GameCycleModule;
using UnityEngine;

namespace GameInit.Builders
{
    public class CitizensBuilder
    {
        public CitizensBuilder(GameCycle cycle)
        {
            var citizens = Object.FindObjectOfType<CitizenComponent>(true);
        }
    }
}
