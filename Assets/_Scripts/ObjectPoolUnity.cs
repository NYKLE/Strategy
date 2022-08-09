using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace GameInit.Utility
{
    public class ObjectPoolUnity : MonoBehaviour
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public bool CollectionCheck { get; private set; }
        [field: SerializeField] public int DefaultCapacity { get; private set; }
        [field: SerializeField] public int MaxSize { get; private set; }


        public ObjectPool<GameObject> Pool { get; set; }
        public List<GameObject> ActiveObjects { get; private set; }

        private GameObject[] _preFireObjects;

        private void Awake()
        {
            ActiveObjects = new List<GameObject>(128);
            Pool = new ObjectPool<GameObject>(
                () => Create(Prefab),
                OnGet,
                OnRelease,
                Destroy,
                CollectionCheck,
                DefaultCapacity,
                MaxSize
            );

            _preFireObjects = new GameObject[DefaultCapacity];
            for (int i = 0; i < DefaultCapacity; i++)
            {
                _preFireObjects[i] = Pool.Get();
            }

            for (int i = 0; i < DefaultCapacity; i++)
            {
                Pool.Release(_preFireObjects[i]);
            }
        }

        private GameObject Create(GameObject objectToSpawn)
        {
            return Instantiate(objectToSpawn, gameObject.transform);
        }

        private void OnGet(GameObject go)
        {
            go.SetActive(true);
            ActiveObjects.Add(go);
        }

        private void OnRelease(GameObject go)
        {
            go.SetActive(false);
            ActiveObjects.Remove(go);
        }

        private void Destroy(GameObject go)
        {
            Destroy(go);
        }
    }
}
