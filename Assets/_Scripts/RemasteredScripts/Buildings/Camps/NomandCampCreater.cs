using UnityEngine;
using System.Collections.Generic;
using GamePlay.NomandsCamp;

namespace GameInit.NomandCamp
{
    public class NomandCamppCreater
    {
        private List<NomandsComponent> NomandsComponent = new List<NomandsComponent>();
        public NomandCamppCreater()
        {
            var campsOnMap = Object.FindObjectsOfType<NomandsComponent>();
            foreach (var camp in campsOnMap)
            {
                NomandsComponent.Add(camp);
            }
        }

        public List<NomandsComponent> getAllCamps()
        {
            return NomandsComponent;
        }
    }

}
