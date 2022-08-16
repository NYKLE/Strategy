using UnityEngine;
using System.Collections.Generic;
using GamePlay.NomandsCamp;

namespace GameInit.NomandCam
{
    public class NomandCampCreater
    {
        private List<NomandsComponet> nomandsComponet = new List<NomandsComponet>();
        public NomandCampCreater()
        {
            var campsOnMap = Object.FindObjectsOfType<NomandsComponet>();
            foreach (var camp in campsOnMap)
            {
                nomandsComponet.Add(camp);
            }
        }

        public List<NomandsComponet> getAllCamps()
        {
            return nomandsComponet;
        }
    }

}
