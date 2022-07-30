using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionPlace : MonoBehaviour, ISelectable
{
    [SerializeField] private Canvas _constructionMenuCanvas;
    [SerializeField] private Canvas _constructionProgressBarCanvas;
    [SerializeField] private Image _constructionProgressBarImage;
    [Space]
    [SerializeField] private InitializerLinkHolder _initializerLinkHolder;

    public BuildingType Type { get; set; }
    public int GoldLeft { get; set; }

    private float _constructionTime;
    public float ConstructionTime
    {
        get => _constructionTime;
        set
        {
            _waitForSeconds = new WaitForSeconds(ConstructionTime);
            _constructionTime = value;
        }
    }

    public bool IsReadyToBuild { get; set; }

    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

    private float _constructionProgressCurrent;
    private bool _isSelectable = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Coin coin) && IsReadyToBuild)
        {
            coin.Hide();

            GoldLeft--;
            if (GoldLeft == 0)
            {
                if (_coroutine == null)
                {
                    _coroutine = StartCoroutine(Construct());
                }
            }
        }
    }

    private IEnumerator Construct()
    {
        _constructionProgressBarCanvas.enabled = true;
        _constructionMenuCanvas.enabled = false;
        _isSelectable = false;
        StartConstructFX();

        while (_constructionProgressCurrent < ConstructionTime)
        {
            _constructionProgressCurrent += Time.deltaTime;

            _constructionProgressBarImage.fillAmount = _constructionProgressCurrent / ConstructionTime;
            yield return null;
        }

        yield return _waitForSeconds;

        _initializerLinkHolder.BuildingsManager.AddBuilding(new Building(Type));

        // TODO: Spawn new building

        _constructionProgressBarCanvas.enabled = false;
        FinishConstructFX();

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
