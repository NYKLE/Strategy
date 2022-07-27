using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceZone : MonoBehaviour, ISelectable
{
    [SerializeField] private ResourceZoneType _resourceZoneType;
    [field: SerializeField] public int Wealth { get; private set; }

    [Header("Enter / Exit Point")] 
    [SerializeField] private Transform _enterExitPoint;

    [Header("Selection FX")] 
    [SerializeField] private SpriteRenderer _selectedSprite;

    [Header("UI")]
    [SerializeField] private int _workersMaxAmount;

    [SerializeField] private Canvas _canvas;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _sliderCurrentText;

    private int _workersCurrentAmount;

    public void OnSelect()
    {
        UpdateData();

        _selectedSprite.enabled = true;
        _canvas.enabled = true;
    }

    private void UpdateData()
    {
        _slider.maxValue = _workersMaxAmount;
    }

    // Used in Inspector
    public void OnSliderValueChanged()
    {
        _sliderCurrentText.text = _slider.value.ToString();
    }

    public void OnEnable()
    {
        Events.Cursor.onDeselect += OnDeselect;
    }

    public void OnDisable()
    {
        Events.Cursor.onDeselect -= OnDeselect;
    }

    private void OnDeselect()
    {
        _canvas.enabled = false;
        _selectedSprite.enabled = false;
    }
}
