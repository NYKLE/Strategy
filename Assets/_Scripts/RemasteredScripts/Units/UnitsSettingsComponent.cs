using UnityEngine;

namespace GameInit.UnitsPrefab
{
    public class UnitsSettingsComponent : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;

        public GameObject GetPrefab()
        {
            return prefab;
        }
    }
}

