using UnityEngine;

namespace BOYAREGames.Buildings
{
    public class Forge : MonoBehaviour
    {
        [SerializeField] private GameObject _toolPrefab;
        [SerializeField] private Transform _toolSpawnPosition;
        [SerializeField] private int _costToMakeTool = 2;
        public int CoinInvestments { get; private set; }

        public void AddCoin(int amount)
        {
            CoinInvestments += amount;

            if (CoinInvestments >= _costToMakeTool)
            {
                MakeTool();
            }
        }

        private void MakeTool()
        {
            GameObject go = Instantiate(_toolPrefab, _toolSpawnPosition.position, Quaternion.identity);
            CoinInvestments = 0;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawRay(_toolSpawnPosition.transform.position, Vector3.up);
        }
    }
}
