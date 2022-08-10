using GameInit.Utility;
using UnityEngine;
using UnityEngine.Pool;

namespace GameInit.Component
{
    [RequireComponent(typeof(ObjectPoolUnity))]
    public class CitizenPoolComponent : MonoBehaviour
    {
        [field: SerializeField] public ObjectPoolUnity Pool { get; private set; }
    }
}

