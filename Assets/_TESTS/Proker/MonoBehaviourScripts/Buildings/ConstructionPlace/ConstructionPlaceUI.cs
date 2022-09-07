using UnityEngine;
using UnityEngine.UI;

namespace BOYAREGames.Buildings
{
    public class ConstructionPlaceUI : MonoBehaviour
    {
        [field: SerializeField] public Canvas ProgressBarCanvas { get; private set; }
        [SerializeField] private Image _fillBarImage;

        public void UpdateProgressBar(float amount)
        {
            _fillBarImage.fillAmount = amount;
        }
    }
}
