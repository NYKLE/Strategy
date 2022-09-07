using System.Collections;
using UnityEngine;

namespace BOYAREGames.Buildings
{
    [RequireComponent(typeof(ConstructionPlaceUI))]
    public class ConstructionPlace : MonoBehaviour
    {
        [SerializeField] private GameObject _buildingPrefab;
        [SerializeField] private int _costToBuild = 2;
        [SerializeField] private float _timeToBuild = 5f;

        private ConstructionPlaceUI _constructionPlaceUI;
        private Coroutine _buildCoroutine;
        private WaitForSeconds _waitForBuild;

        private float _currentBuildingTime;

        public int CoinInvestments { get; private set; }

        private void Awake()
        {
            _constructionPlaceUI = GetComponent<ConstructionPlaceUI>();
            _waitForBuild = new WaitForSeconds(_timeToBuild);
        }

        public void AddCoin(int amount)
        {
            CoinInvestments += amount;

            if (CoinInvestments >= _costToBuild)
            {
                _buildCoroutine ??= StartCoroutine(Build());
            }
        }

        private IEnumerator Build()
        {
            _constructionPlaceUI.ProgressBarCanvas.enabled = true;

            while (_currentBuildingTime < _timeToBuild)
            {
                _currentBuildingTime += Time.deltaTime;
                _constructionPlaceUI.UpdateProgressBar(_currentBuildingTime / _timeToBuild);
                yield return null;
            }

            _constructionPlaceUI.ProgressBarCanvas.enabled = false;

            GameObject go = Instantiate(_buildingPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
