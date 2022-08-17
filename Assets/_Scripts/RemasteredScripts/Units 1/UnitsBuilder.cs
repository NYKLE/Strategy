using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.GameCycleModule;
using GameInit.NomandCam;
using GameInit.UnitsPrefab;
using GamePlay.SpawnUnits;
using System;
using GameInit.Pool;

namespace GameInit.UnitsBuilderCreater
{
    public class UnitsBuilder
    {
        public UnitsBuilder(GameCycle cyrcle, NomandCampCreater nomandCampCreater, List<IDisposable> _dispose, Pools _CoinPool)
        {
            var settings = GameObject.FindObjectOfType<UnitsSettingsComponent>();
            UnitsSpawner unitsSpawner = new UnitsSpawner(settings, nomandCampCreater, _dispose, cyrcle, _CoinPool);

            cyrcle.Add(unitsSpawner);

        }
    }
}

