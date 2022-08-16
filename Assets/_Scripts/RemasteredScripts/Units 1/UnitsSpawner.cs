using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.UnitsPrefab;
using GameInit.NomandCam;
using GamePlay.Units;
using GamePlay.NomandsCamp;
using System;
using GameInit.Job;

namespace GamePlay.SpawnUnits
{
    public class UnitsSpawner : IDayChange
    {
        private NomandCampCreater nomandCampCreater;
        UnitsSettingsComponent unitsSettingsComponent;
        List<IDisposable> dispose;
        public UnitsSpawner(UnitsSettingsComponent _unitsSettingsComponent, NomandCampCreater _nomandCampCreater, List<IDisposable> _dispose)
        {
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
                    var AI = new UnitsAI(MonoBehaviour.Instantiate(unitsSettingsComponent.GetPrefab(), camp.GetTransform(), Quaternion.identity), camp);
                    AI.StateChange(new NomandState());
                    dispose.Add(AI);
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
                        var AI = new UnitsAI(MonoBehaviour.Instantiate(unitsSettingsComponent.GetPrefab(), camp.GetTransform(), Quaternion.identity), camp);
                        AI.StateChange(new NomandState());
                        dispose.Add(AI);
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

