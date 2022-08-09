using GameInit.Utility;
using UnityEngine;

namespace GameInit.Component
{
    [RequireComponent(typeof(ObjectPoolUnity))]
    public class CitizenPoolComponent : MonoBehaviour
    {
        public ObjectPoolUnity Pool { get; private set; }

        private void Awake()
        {
            Pool = GetComponent<ObjectPoolUnity>();
        }
    }
}

