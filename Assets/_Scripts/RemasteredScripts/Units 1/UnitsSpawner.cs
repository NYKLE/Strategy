using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.UnitsPrefab;
using GameInit.NomandCam;
using GamePlay.Units;
using GamePlay.NomandsCamp;
using System;
using GameInit.Job;
using GameInit.GameCycleModule;
using GameInit.Pool;
using GameInit.ConnectBuildings;

namespace GamePlay.SpawnUnits
{
    public class UnitsSpawner : IDayChange
    {
        private NomandCampCreater nomandCampCreater;
        private UnitsSettingsComponent unitsSettingsComponent;
        private List<IDisposable> dispose;
        private GameCycle cyrcle;
        private Pools CoinPool;
        ConnectionsBuildings connectionsBuildings;
        public UnitsSpawner(UnitsSettingsComponent _unitsSettingsComponent, NomandCampCreater _nomandCampCreater, List<IDisposable> _dispose, GameCycle _cyrcle, Pools _CoinPool, ConnectionsBuildings _connectionsBuildings)
        {
            connectionsBuildings = _connectionsBuildings;
            CoinPool = _CoinPool;
            cyrcle = _cyrcle;
            dispose = _dispose;
            nomandCampCreater = _nomandCampCreater;
            unitsSettingsComponent = _unitsSettingsComponent;
            InitAllUnits();
        }

        private void InitAllUnits()
        {
            foreach (var camp in nomandCampCreater.getAllCamps())
            {
                for (int i = 0; i < camp.GetMaxCount(); i++)
                {
                    var AI = new UnitsAI(MonoBehaviour.Instantiate(unitsSettingsComponent.GetPrefab(), camp.GetTransform(), Quaternion.identity), camp, cyrcle, CoinPool, dispose, connectionsBuildings);
                    camp.AddCount();
                }
            }
        }

        private void SpawnUnitsOndayChange()
        {
            foreach (var camp in nomandCampCreater.getAllCamps())
            {
                for (int i = 0; i < camp.GetMaxCount(); i++)
                {
                    if (camp.CanAdd())
                    {
                        var AI = new UnitsAI(MonoBehaviour.Instantiate(unitsSettingsComponent.GetPrefab(), camp.GetTransform(), Quaternion.identity), camp, cyrcle, CoinPool, dispose, connectionsBuildings);
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

