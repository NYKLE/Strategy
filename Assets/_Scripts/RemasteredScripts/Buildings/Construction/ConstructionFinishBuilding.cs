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
        private SpawnBuildingRegistration _registration;
        private BuildingBuilder _buildingBuilder;

        public ConstructionFinishBuilding(GameCycle cycle, ConstructionComponent component, SpawnBuildingRegistration registration, BuildingBuilder buildingBuilder)
        {
            _cycle = cycle;
            _component = component;
            _registration = registration;
            _buildingBuilder = buildingBuilder;
        }

        public void OnUpdate()
        {
            if (_component.IsFinishBuilding)
            {
                GameObject go = Object.Instantiate(_component.BuildingPrefab, _component.gameObject.transform.position, Quaternion.identity);
                _buildingBuilder.
                _registration.Add(_component.BuildingType, go);
                _cycle.Remove(this);
            }
        }
    }
}
