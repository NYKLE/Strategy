using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceZone : MonoBehaviour, ISelectable
{
    [SerializeField] private ResourceType _resourceType;

    [Header("UI")] 
    [SerializeField] private TMP_Text _zoneNameText;
    [SerializeField] private TMP_Text _workersAmountText;
    [Space]
    [SerializeField] private Sprite _emptySlotSprite;
    [SerializeField] private Sprite _activeSlotSprite;
    [Space]
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Image[] _images;
    [SerializeField] private ResourceZoneButtonUI[] _buttons;

    private List<Worker> _workers;

    private void Awake()
    {
        _workers = new List<Worker>(10);
    }

    public void OnSelect()
    {
        UpdateWindowData();

        _canvas.enabled = true;
    }

    public void AddWorker(Worker worker)
    {
        _workers.Add(worker);
        UpdateWindowData();
    }

    private void UpdateWindowData()
    {
        _zoneNameText.text = _resourceType.ToString();
        _workersAmountText.text = _workers.Count.ToString();

        // Clear
        for (int i = 0; i < _buttons.Length; i++)
        {
            _images[i].sprite = _emptySlotSprite;
            _buttons[i].SetOccupied(false);
            _buttons[i].SetZone(this);
        }

        // Update
        for (int i = 0; i < _workers.Count; i++)
        {
            _images[i].sprite = _activeSlotSprite;
            _buttons[i].SetOccupied(true);
        }
    }

    public void MoveToPos(RaycastHit hit)
    {
        throw new System.NotImplementedException();
    }
}
