using UnityEngine;

namespace GameInit.PoolPrefabs
{
    public class PrefabPoolHolder : MonoBehaviour
    {
        [SerializeField] private GameObject coin;
        [SerializeField] private GameObject Nomand;
        [SerializeField] private GameObject _citizen;

        public GameObject GetCoinPrefab()
        {
            return coin;
        }
        public GameObject GetNomandPrefab()
        {
            return Nomand;
        }

        public GameObject GetCitizenPrefab()
        {
            return _citizen;
        }
    }
}


