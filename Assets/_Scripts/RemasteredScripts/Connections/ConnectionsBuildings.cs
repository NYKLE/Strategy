using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.Buildings;
using GamePlay.Units;
using System;

namespace GameInit.ConnectBuildings
{
    public class ConnectionsBuildings
    {
        private ConnectionsWorkShop connectionsWorkShop;
        public ConnectionsBuildings(List<IDisposable> _dispose)
        {
            connectionsWorkShop =  new ConnectionsWorkShop();
            _dispose.Add(connectionsWorkShop);
        }

        public ConnectionsWorkShop getConnectionsWorkShop()
        {
            return connectionsWorkShop;
        }
    }
}
