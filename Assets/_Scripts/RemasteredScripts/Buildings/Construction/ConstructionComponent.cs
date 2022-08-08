using UnityEngine;

namespace GameInit.Component
{
    public class ConstructionComponent : MonoBehaviour
    {
        [field: SerializeField] public float ConstructionTime { get; private set; }
        [field: SerializeField] public int GoldNeededToBuild { get; private set; }
        [field: SerializeField] public float ColliderRadius { get; private set; }
    }
}
