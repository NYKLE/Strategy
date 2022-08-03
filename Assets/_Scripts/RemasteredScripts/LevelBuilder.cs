using UnityEngine;
using System.Collections.Generic;
using System;
using GameInit.GameCyrcleModule;

namespace GameInit.Builders
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(GameCyrcle))]

    public class LevelBuilder : MonoBehaviour
    {
        private readonly List<IDisposable> _dispose = new List<IDisposable>();

        private void Awake()
        {
            var GameCyrcle = GetComponent<GameCyrcle>();
            CameraBuilder(GameCyrcle);
        }
        private void OnDestroy()
        {
            foreach (var item in _dispose)
            {
                item.Dispose();
            }
        }
        private void CameraBuilder(GameCyrcle GameCyrcle)
        {
            new CameraBuilder(GameCyrcle);
        }

    }
}


