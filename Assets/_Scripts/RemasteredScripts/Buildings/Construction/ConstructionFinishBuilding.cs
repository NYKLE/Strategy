using System;
using GameInit.Builders;
using GameInit.Component;
using GameInit.GameCycleModule;
using GameInit.Utility;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameInit.Construction
{
    public class ConstructionFinishBuilding : IUpdate
    {
        private GameCycle _cycle;
        private ConstructionComponent _component;

        public ConstructionFinishBuilding(GameCycle cycle, ConstructionComponent component)
        {
            _cycle = cycle;
            _component = component;
        }

        public void OnUpdate()
        {
            if (_component.IsFinishBuilding)
            {
                GameObject go = Object.Instantiate(_component.BuildingPrefab, _component.gameObject.transform.position, Quaternion.identity);
                _cycle.Remove(this);
            }
        }
    }
}
