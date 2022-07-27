using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceZone : MonoBehaviour, ISelectable
{
    [SerializeField] private ResourceZoneType _resourceZoneType;

    [Header("Enter / Exit Point")] 
    [SerializeField] private Transform _enterExitPoint;

    [Header("UI")] 
    [SerializeField] private TMP_Text _zoneNameText;
    [SerializeField] private TMP_Text _workersAmountText;
    [Space]
    [SerializeField] private Sprite _emptySlotSprite;
    [SerializeField] private Sprite _walkingSlotSprite;
    [SerializeField] private Sprite _activeSlotSprite;
    [SerializeField] private Sprite _returningSlotSprite;
    [Space]
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Image[] _images;

    [SerializeField] private ResourceZoneAddOrReleaseWorkerButton[] _buttons;

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

    public void UpdateWindowData()
    {
        _workers.Clear();

        for (int i = 0; i < WorkerManager.Instance.GetWorkers().Count; i++)
        {
            if (WorkerManager.Instance.GetWorkers()[i].GetResourceZone() == this)
            {
                _workers.Add(WorkerManager.Instance.GetWorkers()[i]);
            }
        }

        _zoneNameText.text = _resourceZoneType.ToString();
        _workersAmountText.text = _workers.Count.ToString();

        for (int i = 0; i < _images.Length; i++)
        {
            _images[i].sprite = _emptySlotSprite;
        }

        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].SetZone(this);
        }

        for (int i = 0; i < _workers.Count; i++)
        {
            switch (_workers[i].GetState())
            {
                case WorkerState.Free:
                    _images[i].sprite = _emptySlotSprite;
                    break;
                case WorkerState.Walking:
                    _images[i].sprite = _walkingSlotSprite;
                    break;
                case WorkerState.Working:
                    _images[i].sprite = _activeSlotSprite;
                    break;
                case WorkerState.Returning:
                    _images[i].sprite = _returningSlotSprite;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public List<Worker> GetWorkers()
    {
        return _workers;
    }

    public void RemoveWorker(Worker worker)
    {
        _workers.Remove(worker);
    }

    public Vector3 GetEnterExitPoint()
    {
        return _enterExitPoint.position;
    }

    public void MoveToPos(RaycastHit hit)
    {
        throw new System.NotImplementedException();
    }
}
