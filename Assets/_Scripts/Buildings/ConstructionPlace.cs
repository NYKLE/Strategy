using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionPlace : MonoBehaviour, ISelectable
{
    [SerializeField] private float _constructionTime;
    [field: SerializeField] public int GoldNeededToBuild { get; private set; }

    [Space]
    [SerializeField] private GameObject _buildingPrefabToBuild;
    [SerializeField] private Canvas _constructionMenuCanvas;
    [SerializeField] private Canvas _constructionProgressBarCanvas;
    [SerializeField] private Image _constructionProgressBarImage;
    [SerializeField] private TMP_Text _goldLefText;
    [SerializeField] private BoxCollider _triggerBoxCollider;

    private Coroutine _coroutine;

    private float _constructionProgressCurrent;
    private bool _isSelectable = true;

    private void Start()
    {
        _goldLefText.text = GoldNeededToBuild.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            coin.Hide();

            GoldNeededToBuild--;
            if (GoldNeededToBuild == 0)
            {
                if (_coroutine == null)
                {
                    _coroutine = StartCoroutine(Construct());
                }
            }

            _goldLefText.text = GoldNeededToBuild.ToString();
        }
    }

    private IEnumerator Construct()
    {
        _constructionProgressBarCanvas.enabled = true;
        _constructionMenuCanvas.enabled = false;
        _isSelectable = false;
        _constructionProgressCurrent = 0f;
        _triggerBoxCollider.enabled = false;
        StartConstructFX();

        while (_constructionProgressCurrent < _constructionTime)
        {
            _constructionProgressCurrent += Time.deltaTime;

            _constructionProgressBarImage.fillAmount = _constructionProgressCurrent / _constructionTime;
            yield return null;
        }

        _constructionProgressBarCanvas.enabled = false;
        FinishConstructFX();

        var siblingIndex = transform.GetSiblingIndex();
        var go = Instantiate(_buildingPrefabToBuild, transform.position, Quaternion.identity);
        go.transform.SetSiblingIndex(siblingIndex);
        Destroy(gameObject);

        _coroutine = null;
    }

    private void StartConstructFX()
    {
        // TODO: Start Construct FX
    }

    private void FinishConstructFX()
    {
        // TODO: Finish Construct FX
    }

    public void OnSelect()
    {
        if (_isSelectable)
        {
            _constructionMenuCanvas.enabled = true;
        }
    }

    public void OnDeselect()
    {
        _constructionMenuCanvas.enabled = false;
    }

    private void OnEnable()
    {
        Events.Cursor.onDeselect += OnDeselect;
    }

    private void OnDisable()
    {
        Events.Cursor.onDeselect -= OnDeselect;
    }

}
