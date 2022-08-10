using GameInit.Component;
using GameInit.Utility;
using UnityEngine;

namespace GameInit.Builders
{
    public class CitizenPoolBuilder
    {
        public ObjectPoolUnity CitizenPool { get; private set; }

        public CitizenPoolBuilder()
        {
            CitizenPoolComponent pool = Object.FindObjectOfType<CitizenPoolComponent>();

            CitizenPool = pool.Pool;
        }
    }
}

