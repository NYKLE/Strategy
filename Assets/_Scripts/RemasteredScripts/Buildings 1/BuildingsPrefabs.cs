using UnityEngine;
using GamePlay.WorkShop;
using System.Collections.Generic;

namespace GameInit.Settings 
{
    public class BuildingsPrefabs : MonoBehaviour
    {
        [SerializeField] private  GameObject _WorkShopPrefab;
       
        public GameObject getWorkShopPrefab()
        {
            return _WorkShopPrefab;
        }
        
    }

}

