using UnityEngine;
using System.Collections.Generic;

namespace GamePlay.WorkShop
{
    public class ToolsPrefabsComponent : MonoBehaviour
    {
        private Dictionary<WorkShopTools, GameObject> ToolsPrefabsComponentList;
        [SerializeField] List<WorkShopTools> _Keys;
        [SerializeField] List<GameObject> _Values;

        private void OnEnable()
        {
            ToolsPrefabsComponentList = new Dictionary<WorkShopTools, GameObject>();

            for (int i = 0; i < _Keys.Count; i++)
            {
                ToolsPrefabsComponentList.Add(_Keys[i], _Values[i]);
            }
        }
        public Dictionary<WorkShopTools, GameObject> getDictionary()
        {
            return ToolsPrefabsComponentList;
        }
    }
}
