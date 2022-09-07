using System;

namespace BOYAREGames.Events
{
    public static class Events
    {
        public struct Player
        {
            public static Action DropCoin;
        }

        public struct Civilian
        {
            public static Action<Units.Civilian> Spawn;
        }

        public struct Nomad
        {
            public static Action<Units.Nomad> DestroyAction;
        }
    }
}
