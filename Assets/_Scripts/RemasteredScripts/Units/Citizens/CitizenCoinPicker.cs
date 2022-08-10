using System.Collections.Generic;
using GameInit.Component;
using GameInit.Pool;
using UnityEngine;

namespace GameInit.Citizen
{
    public class CitizenCoinPicker : IUpdate
    {
        private Pools _pool;
        private List<CitizenComponent> citizens;

        public CitizenCoinPicker(CitizenComponent citizenComponent, Pools pool)
        {
            _pool = pool;
            citizens = new List<CitizenComponent>(pool._pool.Count);

            foreach (var citizen in pool._pool)
            {
                citizens.Add(citizen.GetComponent<CitizenComponent>());
            }
        }

        public void OnUpdate()
        {
            foreach (var citizen in citizens)
            {
                //if (citizen.IsGoingForACoin == false && citizen.IsCoinsInRadius) 
                if (citizen.IsCoinsInRadius && citizen.IsGoingForACoin == false)
                {
                    citizen.GoesForACoin();
                }
            }
        }
    }
}
