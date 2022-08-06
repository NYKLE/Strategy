using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameInit.PoolOfCoins
{
    public class CoinsPool : MonoBehaviour
    {
        [SerializeField] private GameObject prefabCoin;

        [Space(10)] [SerializeField] private Transform _container;
        [SerializeField] private int _minCapacity;
        [SerializeField] private int _maxCapacity;
        [Space(10)] [SerializeField] private bool _isExpand;

        private List<GameObject> _pool;
        private void OnExpand()
        {
            if (_isExpand)
            {
                _maxCapacity = Int32.MaxValue;
            }
        }

        public void CreatPool()
        {
            _pool = new List<GameObject>();

            for (int i = 0; i < _minCapacity; i++)
            {
                CreateObj();
            }
        }
        private GameObject CreateObj(bool isActibebydefault = false)
        {
            var createdObj = Instantiate(prefabCoin, _container);
            createdObj.gameObject.SetActive(isActibebydefault);

            _pool.Add(createdObj);

            return createdObj;
        }
        public bool TryGetElement(out GameObject gameobj)
        {
            foreach (var item in _pool)
            {
                if (!item.gameObject.activeInHierarchy)
                {
                    gameobj = item;
                    item.gameObject.SetActive(true);
                    return true;
                }
            }
            gameobj = null;
            return false;
        }

        public GameObject GetFreeElements(Vector3 pos, Quaternion rotation)
        {
            var obj = GetFreeElements(pos);
            obj.transform.rotation = rotation;
            return obj;
        }
        public GameObject GetFreeElements(Vector3 pos)
        {
            var obj = GetFreeElements();
            obj.transform.position = pos;
            return obj;
        }
        public GameObject GetFreeElements()
        {
            if(TryGetElement(out var gameObj))
            {
                return gameObj;
            }
            if (_isExpand)
            {
                return CreateObj(true);
            }

            if(_pool.Count < _maxCapacity)
            {
                return CreateObj(true);
            }
            throw new Exception("Pool is over!");
        }
    }
}

