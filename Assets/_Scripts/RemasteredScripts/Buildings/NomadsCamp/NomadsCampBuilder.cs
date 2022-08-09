using GameInit.Component;
using GameInit.GameCycleModule;
using GameInit.Utility;
using UnityEngine;

namespace GameInit.Builders
{
    public class NomadsCampBuilder
    {
        public ObjectPoolUnity Pool { get; private set; }

        private NomadsCampComponent[] _camps;


        public NomadsCampBuilder(GameCycle cycle)
        {
            _camps = Object.FindObjectsOfType<NomadsCampComponent>();
        }
    }
}
