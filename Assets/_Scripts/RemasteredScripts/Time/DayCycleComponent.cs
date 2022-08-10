using UnityEngine;

namespace GameInit.Component
{
    public class DayCycleComponent : MonoBehaviour
    {
        [field: SerializeField, Min(0.1f)] public float DayLength { get; private set; }
    }
}
