using System;
using UnityEngine;

namespace GameInit.Buildings
{
    public interface IBuildings
    {
        public Action<Transform> sendTransform { get; set; }
    }

}
