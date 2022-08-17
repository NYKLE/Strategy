using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameInit.Job
{
    public class NomandState : IJob
    {
        public NomandState()
        {
            Enter();
        }
        public void Enter()
        {
            Debug.Log("First State");
        }





    }
}

