using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.GameCyrcleModule;
using GameInit.NomandCamp;
using GameInit.UnitsPrefab;
using GamePlay.SpawnUnits;
using System;
using GameInit.Pool;
using GameInit.ConnectBuildings;

namespace GameInit.UnitsBuilderCreater
{
    public class UnitsBuilder
    {
        public UnitsBuilder(GameCyrcle cyrcle, NomandCamppCreater NomandCamppCreater, List<IDisposable> _dispose, Pools _coinPool, ConnectionsBuildings connectionsBuildings)
        {
            var settings = GameObject.FindObjectOfType<UnitsSettingsComponent>();
            UnitsSpawner unitsSpawner = new UnitsSpawner(settings, NomandCamppCreater, _dispose, cyrcle, _coinPool, connectionsBuildings);

            cyrcle.Add(unitsSpawner);

        }
    }
}

