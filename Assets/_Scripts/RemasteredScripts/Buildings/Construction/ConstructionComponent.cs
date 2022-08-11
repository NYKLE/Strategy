using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace GameInit.Component
{
    [RequireComponent(typeof(Rigidbody))]
    public class ConstructionComponent : MonoBehaviour, ISelectable
    {
        [field: SerializeField] public BuildingType BuildingType { get; private set; }
        //[field: SerializeField] public LocalizedString BuildingName { get; private set; }
        [field: SerializeField] public GameObject BuildingPrefab { get; private set; }
        [field: SerializeField] public float ConstructionTime { get; private set; }
        [field: SerializeField] public int GoldNeededToBuild { get; private set; }
        [field: SerializeField] public float ColliderRadius { get; private set; }
        public Collider Trigger { get; private set; }
        public bool IsFinishBuilding { get; private set; }

        [field: SerializeField] public Canvas CanvasMain { get; private set; }
        [field: SerializeField] public TMP_Text GoldLeftText { get; private set; }
        [field: SerializeField] public TMP_Text BuildingNameText { get; private set; }

        [field: SerializeField] public Canvas CanvasProgressBar { get; private set; }
        [field: SerializeField] public Image ProgressBar { get; private set; }

        private Coroutine _coroutine;
        private WaitForEndOfFrame _waitForEndOfFrame;
        private float _constructionProgressCurrent;
        private bool _isSelectable = true;

        private void Awake()
        {
            if (Trigger == null)
            {
                Trigger = GetComponent<Collider>();
            }

            GetComponent<Rigidbody>().isKinematic = true;
        }

        private void Start()
        {
            GoldLeftText.text = GoldNeededToBuild.ToString();
            //BuildingNameText.text = BuildingName.GetLocalizedString();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Coin coin))
            {
                GoldNeededToBuild--;
                GoldLeftText.text = GoldNeededToBuild.ToString();

                if (GoldNeededToBuild == 0)
                {
                    _coroutine ??= StartCoroutine(Construct());
                }

                coin.Hide();
            }
        }

        private IEnumerator Construct()
        {
            CanvasMain.enabled = false;
            CanvasProgressBar.enabled = true;

            _isSelectable = false;
            _constructionProgressCurrent = 0f;
            Trigger.enabled = false;

            while (_constructionProgressCurrent < ConstructionTime)
            {
                _constructionProgressCurrent += Time.deltaTime;

                ProgressBar.fillAmount = _constructionProgressCurrent / ConstructionTime;
                yield return null;
            }

            ProgressBar.enabled = false;

            //var go = Instantiate(BuildingPrefab, gameObject.transform.position, Quaternion.identity);
            //BuildingToBuild.SetActive(true);

            IsFinishBuilding = true;

            yield return _waitForEndOfFrame;

            Destroy(gameObject);
            //gameObject.SetActive(false);

            _coroutine = null;
        }

        public void OnSelect()
        {
            if (!_isSelectable) return;
            CanvasMain.enabled = true;
        }

        public void OnDeselect()
        {
            CanvasMain.enabled = false;
        }
    }
}
