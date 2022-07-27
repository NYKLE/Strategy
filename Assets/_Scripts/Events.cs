using System;
using UnityEngine;

public static class Events
{
    public struct Cursor
    {
        public static Action onDeselect;
    }

    public struct Unit
    {
        public static Action<GameObject> onUnitSpawn;
        public static Action<GameObject> onUnitDeath;
    }
}
