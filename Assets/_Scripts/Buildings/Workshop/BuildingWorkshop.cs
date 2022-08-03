using System;
using UnityEngine;

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
                    break;
                case ToolType.Hammer:
                    tool = Instantiate(_hammerPrefab, transform.position, Quaternion.identity);
                    break;
                case ToolType.Sword:
                    tool = Instantiate(_swordPrefab, transform.position, Quaternion.identity);
                    break;
                case ToolType.Bow:
                    tool = Instantiate(_bowPrefab, transform.position, Quaternion.identity);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            coin.Hide();
            tool.transform.position = _toolSpawnPointTransform.position;
        }
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
