using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.GameCycleModule;
using GameInit.NomandCam;
using GameInit.UnitsPrefab;
using GamePlay.SpawnUnits;
using System;
using GameInit.Pool;
using GameInit.ConnectBuildings;

namespace GameInit.UnitsBuilderCreater
{
    public class UnitsBuilder
    {
        public UnitsBuilder(GameCycle cyrcle, NomandCampCreater nomandCampCreater, List<IDisposable> _dispose, Pools _CoinPool, ConnectionsBuildings connectionsBuildings)
        {
            var settings = GameObject.FindObjectOfType<UnitsSettingsComponent>();
            UnitsSpawner unitsSpawner = new UnitsSpawner(settings, nomandCampCreater, _dispose, cyrcle, _CoinPool, connectionsBuildings);

            cyrcle.Add(unitsSpawner);

        }
    }
}

