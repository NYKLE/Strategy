using System;
using GameInit.GameCyrcleModule;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameInit.Chest
{
    public class ChestCollider : ICallable
    {
        private ChestSettings _chestSettings;
        private HeroSettings _heroSettings;

        private float _distance;

        public ChestCollider(ChestSettings chestSettings, HeroSettings heroSettings)
        {
            _chestSettings = chestSettings;
            _heroSettings = heroSettings;
        }

        public void UpdateCall()
        {
            _distance = Vector3.Distance(_chestSettings.transform.position, _heroSettings.transform.position);
            if (_distance <= _chestSettings.ColliderRadius)
            {

                Object.Destroy(_chestSettings.gameObject);
            }
        }
    }
}
