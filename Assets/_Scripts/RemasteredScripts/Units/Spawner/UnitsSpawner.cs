using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.UnitsPrefab;
using GameInit.NomandCamp;
using GamePlay.Units;
using System;
using GameInit.Job;
using GameInit.GameCyrcleModule;
using GameInit.Pool;
using GameInit.ConnectBuildings;

namespace GamePlay.SpawnUnits
{
    public class UnitsSpawner : IDayChange
    {
        private NomandCamppCreater NomandCamppCreater;
        private UnitsSettingsComponent unitsSettingsComponent;
        private List<IDisposable> dispose;
        private GameCyrcle cyrcle;
        private Pools coinPool;
        ConnectionsBuildings connectionsBuildings;
        public UnitsSpawner(UnitsSettingsComponent _unitsSettingsComponent, NomandCamppCreater _NomandCamppCreater, List<IDisposable> _dispose, GameCyrcle _cyrcle, Pools _coinPool, ConnectionsBuildings _connectionsBuildings)
        {
            connectionsBuildings = _connectionsBuildings;
            coinPool = _coinPool;
            cyrcle = _cyrcle;
            dispose = _dispose;
            NomandCamppCreater = _NomandCamppCreater;
            unitsSettingsComponent = _unitsSettingsComponent;
            InitAllUnits();
        }

        private void InitAllUnits()
        {
            foreach (var camp in NomandCamppCreater.getAllCamps())
            {
                for (int i = 0; i < camp.GetMaxCount(); i++)
                {
                    var AI = new UnitsAI(MonoBehaviour.Instantiate(unitsSettingsComponent.GetPrefab(), camp.GetTransform(), Quaternion.identity), camp, cyrcle, coinPool, dispose, connectionsBuildings);
                    camp.AddCount();
                }
            }
        }

        private void SpawnUnitsOndayChange()
        {
            foreach (var camp in NomandCamppCreater.getAllCamps())
            {
                for (int i = 0; i < camp.GetMaxCount(); i++)
                {
                    if (camp.CanAdd())
                    {
                        var AI = new UnitsAI(MonoBehaviour.Instantiate(unitsSettingsComponent.GetPrefab(), camp.GetTransform(), Quaternion.identity), camp, cyrcle, coinPool, dispose, connectionsBuildings);
                        camp.AddCount();
                    }
                }
            }
        }
        public void OnDayChange()
        {
            SpawnUnitsOndayChange();
        }
    }
}

