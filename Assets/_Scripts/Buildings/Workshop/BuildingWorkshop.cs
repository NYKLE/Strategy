using System;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(SphereCollider))]
public class BuildingWorkshop : BuildingBase, ISelectable
{
    [field: SerializeField] public ToolType ToolType { get; set; }
    [Space]
    [SerializeField] private GameObject _pitchforkPrefab;
    [SerializeField] private GameObject _hammerPrefab;
    [SerializeField] private GameObject _swordPrefab;
    [SerializeField] private GameObject _bowPrefab;
    [Space] 
    [SerializeField] private Canvas _canvas;

    [SerializeField] private Transform _toolSpawnPointTransform;

    private int _coinsLeft;

    private Dictionary<ToolType, GameObject> tools = new Dictionary<ToolType, GameObject>();

    private SphereCollider _coinTrigger;
    
    private void Awake()
    {
        _coinTrigger = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            GameObject tool = null;
            switch (ToolType)
            {
                case ToolType.Pitchfork:
                    tool = Instantiate(_pitchforkPrefab, transform.position, Quaternion.identity);
                    tools.Add(ToolType.Pitchfork, tool);
                    break;
                case ToolType.Hammer:
                    tool = Instantiate(_hammerPrefab, transform.position, Quaternion.identity);
                    tools.Add(ToolType.Hammer, tool);
                    break;
                case ToolType.Sword:
                    tool = Instantiate(_swordPrefab, transform.position, Quaternion.identity);
                    tools.Add(ToolType.Sword, tool);
                    break;
                case ToolType.Bow:
                    tool = Instantiate(_bowPrefab, transform.position, Quaternion.identity);
                    tools.Add(ToolType.Bow, tool);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            coin.Hide();
            tool.transform.position = _toolSpawnPointTransform.position;
        }
    }

    public bool GetTools(out Dictionary<ToolType, GameObject> dictionary)
    {
        dictionary = tools;
        if(dictionary.Count != 0)
        {
            return true;
        }
        return false;
    }
    public void OnSelect()
    {
        _canvas.enabled = true;
    }

    public void OnDeselect()
    {
        _canvas.enabled = false;
    }

    public override void OnEnable()
    {
        base.OnEnable();

        Events.Cursor.onDeselect += OnDeselect;
    }

    public override void OnDisable()
    {
        base.OnDisable();

        Events.Cursor.onDeselect -= OnDeselect;
    }
}
