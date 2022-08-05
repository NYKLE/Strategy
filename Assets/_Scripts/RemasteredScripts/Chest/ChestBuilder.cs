using System.Collections.Generic;
using GameInit.Chest;
using GameInit.GameCyrcleModule;
using UnityEngine;

namespace GameInit.Builders
{
    public class ChestBuilder
    {
        public List<ChestCollider> Colliders { get; private set; }
        public ChestBuilder(GameCycle cycle, HeroSettings heroSettings)
        {
            Colliders = new List<ChestCollider>();
            ChestSettings[] chestSettings = Object.FindObjectsOfType<ChestSettings>();

            foreach (var settings in chestSettings)
            {
                Debug.Log($"Chest Settings: {settings}, Hero Settings: {heroSettings}");
                var chestCollider = new ChestCollider(settings, heroSettings);
                Colliders.Add(chestCollider);

                cycle.Add(CycleMethod.Update, chestCollider);
            }
        }
    }
}
