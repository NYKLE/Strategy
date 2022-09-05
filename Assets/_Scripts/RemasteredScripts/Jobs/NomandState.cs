using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameInit.Job
{
    public class NomandState : IJob
    {
        private GameObject prefab;
        public NomandState(GameObject _prefab)
        {
            prefab = _prefab;
            Enter();
        }
        public void Enter()
        {
            Debug.Log("First State");
        }

        public Vector3 getPosition()
        {
            return prefab.transform.position;
        }

        public void setWay(Vector3 way)
        {
            
        }
    }
}

