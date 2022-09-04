using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.Buildings;
using GamePlay.Units;
using System;
using GameInit.Job;

namespace GameInit.ConnectBuildings
{
    public class ConnectionsWorkShop : IDisposable
    {
        private List<IBuildings> workShops;

        private List<IJob> units;

        public ConnectionsWorkShop()
        {
            workShops = new List<IBuildings>();
            units = new List<IJob>();
        }

        public void addWorkshops(IBuildings workShop)
        {
            workShops.Add(workShop);
            workShops[workShops.Count - 1].sendTransform += sendDataToUnits;
        }

        public void addUnits(IJob unit)
        {
            units.Add(unit);
        }

        private void sendDataToUnits(Transform trans)
        {
            getClosestUnit(trans.position).setWay(trans.localPosition);
        }

        private IJob getClosestUnit(Vector3 pos)
        {

            if (units == null && units.Count == 0)
            {
                return null;
            }

            Vector3 curUnit = new Vector3(
                units[0].getPosition().x - pos.x,
                units[0].getPosition().y - pos.y,
                units[0].getPosition().z - pos.z);

            double curUnitDistance = Math.Sqrt(
            Math.Pow(curUnit.x, 2d) +
            Math.Pow(curUnit.y, 2d) +
            Math.Pow(curUnit.z, 2d));

            IJob closestUnit = units[0];

            for (int i = 0; i < units.Count; i++)
            {
                Vector3 difference = new Vector3(
                units[i].getPosition().x - pos.x,
                units[i].getPosition().y - pos.y,
                units[i].getPosition().z - pos.z);

                double distance = Math.Sqrt(
                Math.Pow(difference.x, 2d) +
                Math.Pow(difference.y, 2d) +
                Math.Pow(difference.z, 2d));

                if (curUnitDistance > distance)
                {
                    curUnitDistance = distance;
                    closestUnit = units[i];
                }
            }

            return closestUnit;
        }

        public void Dispose()
        {
            foreach (var workShop in workShops)
            {
                workShop.sendTransform -= sendDataToUnits;
            }
        }
    }
}


