using System;
using System.Collections.Generic;
using UnityEngine;

public class UIConstructionButton : MonoBehaviour
{
    [SerializeField] private BuildingType _type;
    [SerializeField] private GameObject _buildingPrefabs;

    private ConstructionPlace _constructionPlace;

    private void Awake()
    {
        _constructionPlace = GetComponentInParent<ConstructionPlace>();
    }

    public void OnClick()
    {
        _constructionPlace.Type = _type;
        _constructionPlace.IsReadyToBuild = true;

        switch (_type)
        {
            case BuildingType.TownHall:
                // TODO: UIConstructionButton - Switch(BuildingType)
                break;
            case BuildingType.Farm:
                _constructionPlace.ConstructionTime = 10f;
                _constructionPlace.GoldLeft = 2;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
