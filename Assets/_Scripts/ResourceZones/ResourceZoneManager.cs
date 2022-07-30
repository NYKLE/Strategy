using System;
using System.Collections.Generic;

public class ResourceZoneManager
{
    public List<ResourceZone> Zones { get;}

    public static Action<ResourceZone> addZoneAction;

    public ResourceZoneManager()
    {
        Zones = new List<ResourceZone>();
    }

    public void AddZone(ResourceZone zone)
    {
        Zones.Add(zone);
    }
}
