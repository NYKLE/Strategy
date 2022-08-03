using UnityEngine;
using GameInit.Camera;
using GameInit.GameCyrcleModule;
using System.Linq;
using GameInit.Utility;

namespace GameInit.Builders
{
    public class CameraBuilder
    {
       public CameraBuilder(GameCyrcle cyrcle)
        {
           var cameraTransform = Object
                 .FindObjectsOfType<GameObject>()
                 .First(go => go.layer == (int)Layers.CameraMain)
                 .transform;
            var settings = Object.FindObjectOfType<CameraSettings>();
            var cameraMove = new CameraMove(settings, cameraTransform);
            
            cyrcle.Add(CycleMethod.Update, cameraMove);
        }
    }
}

