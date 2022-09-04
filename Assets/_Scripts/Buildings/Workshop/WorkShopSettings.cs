using UnityEngine;
using System.Collections.Generic;

namespace GamePlay.WorkShop
{
    public class WorkShopSettings : MonoBehaviour
    {
        [SerializeField] private GameObject _buildingPlace;
        [SerializeField] private GameObject _building;
        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject toolsSpawnPoint;
        [SerializeField] private WorkShopTypes type;
        
        public Vector3 getSpawnPoint()
        {
            return toolsSpawnPoint.transform.position;
        }
        public GameObject getBuildingPlace()
        {
            return _buildingPlace;
        }
        public GameObject getBuilding()
        {
            return _building;
        }
        public WorkShopTypes getType()
        {
            return type;
        }
        public GameObject getPrefab()
        {
            return prefab;
        }
    }
}


