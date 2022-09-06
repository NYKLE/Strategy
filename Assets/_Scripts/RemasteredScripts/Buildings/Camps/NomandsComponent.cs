using UnityEngine;

namespace GamePlay.NomandsCamp
{
    public class NomandsComponent : MonoBehaviour
    {
        [SerializeField] private int maxCount = 5;
        [SerializeField] private int curCount = 0;
        [SerializeField] private Transform trans;
        private const int minCount = 0;

        public int GetMaxCount()
        {
            return maxCount;
        }
        public Vector3 GetTransform()
        {
            return trans.position;
        }
        public bool CanAdd()
        {
            if (curCount < maxCount)
            {
                return true;
            }

            return false;
        }
        public void AddCount()
        {
            if (curCount < maxCount)
            {
                curCount++;
            }
        }
        public void DecriseCount()
        {
            if (curCount > minCount)
            {
                curCount--;
            }
        }
        public void DisableObj()
        {
            gameObject.SetActive(false);
        }
    }

}
