using System.Collections.Generic;
using GameInit.Component;
using GameInit.GameCycleModule;
using UnityEngine;

namespace GameInit.Builders
{
    public class BuildingBuilder
    {
        public List<object> Farm { get; private set; }
        public List<WorkshopComponent> Workshop { get; private set; }

        private GameCycle _cycle;

        public BuildingBuilder(GameCycle cycle)
        {
            Farm = new List<object>(32);
            Workshop = new List<WorkshopComponent>(32);
        }

        public void Add(FarmComponent farm)
        {
            Farm.Add(farm);
        }

        public void Add(WorkshopComponent workshop)
        {
            Workshop.Add(workshop);
        }
    }
}

