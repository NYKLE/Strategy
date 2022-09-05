using UnityEngine;

namespace GameInit.Job
{
    public interface IJob
    {
        public void Enter();
        public void setWay(Vector3 way);
        public Vector3 getPosition();
    }
}

