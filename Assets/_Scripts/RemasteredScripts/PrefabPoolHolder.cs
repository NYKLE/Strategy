using UnityEngine;

namespace GameInit.PoolPrefabs
{
    public class PrefabPoolHolder : MonoBehaviour
    {
        [SerializeField] private GameObject coin;
        [SerializeField] private GameObject Nomand;

        public GameObject GetCoinPrefab()
        {
            return coin;
        }
        public GameObject GetNomandPrefab()
        {
            return Nomand;
        }
    }
}


