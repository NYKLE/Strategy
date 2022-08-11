using UnityEngine;

namespace GameInit.Component
{
    public class FarmComponent : MonoBehaviour
    {
        [field: SerializeField] public int HealthMax { get; set; }
        [field: SerializeField] public int HealthCurrent { get; set; }
        [field: SerializeField] public BuildingState State { get; set; }

        [field: SerializeField] public int FarmersMaxCanHave { get; private set; }
        [field: SerializeField] public int FarmersCurrentHave { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HeroComponent hero))
            {

            }
        }
    }
}
