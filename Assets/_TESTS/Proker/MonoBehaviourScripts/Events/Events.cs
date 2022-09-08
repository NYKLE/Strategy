using System;

namespace BOYAREGames.Events
{
    public static class Events
    {
        public struct Player
        {
            public static Action onDropCoinAction;
        }

        public struct Civilian
        {
            public static Action<Units.Civilian> onSpawnAction;
        }

        public struct Nomad
        {
            public static Action<Units.Nomad> onDestroyAction;
        }

        public struct Coin
        {
            public static Action<Collectable.Coin> onDestroyAction;
        }
    }
}
