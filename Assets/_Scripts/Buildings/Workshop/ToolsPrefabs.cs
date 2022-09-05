using UnityEngine;
using System.Collections.Generic;

namespace GamePlay.WorkShop
{
    public class ToolsPrefabs : MonoBehaviour
    {
        private Dictionary<WorkShopTools, GameObject> toolsPrefabsList;
        [SerializeField] List<WorkShopTools> _Keys;
        [SerializeField] List<GameObject> _Values;

        private void OnEnable()
        {
            toolsPrefabsList = new Dictionary<WorkShopTools, GameObject>();

            for (int i = 0; i < _Keys.Count; i++)
            {
                toolsPrefabsList.Add(_Keys[i], _Values[i]);
            }
        }
        public Dictionary<WorkShopTools, GameObject> getDictionary()
        {
            return toolsPrefabsList;
        }
    }
}
