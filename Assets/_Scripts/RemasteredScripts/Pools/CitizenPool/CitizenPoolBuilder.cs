using GameInit.Component;
using GameInit.Utility;
using UnityEngine;

namespace GameInit.Builders
{
    public class CitizenPoolBuilder
    {
        public ObjectPoolUnity Pool { get; private set; }
        public CitizenPoolBuilder()
        {
            CitizenPoolComponent pool = Object.FindObjectOfType<CitizenPoolComponent>();
            Pool = pool.Pool;
        }
    }
}

