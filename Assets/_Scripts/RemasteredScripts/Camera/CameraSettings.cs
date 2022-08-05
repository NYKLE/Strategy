using UnityEngine;

namespace GameInit.Camera
{
    public class CameraSettings : MonoBehaviour
    {
        [field: SerializeField] public int speed { get; private set; }
        [field: SerializeField] public int dragSpeed { get; private set; }
        [field: SerializeField] public int minHight { get; private set; }
        [field: SerializeField] public int maxHight { get; private set; }
        [field: SerializeField] public int scrollSpeed { get; private set; }
        [field: SerializeField] public int panBorderThicknes { get; private set; }
        [field: SerializeField] public Vector2 limitPan { get; private set; }
        [field: SerializeField] public Vector3 originPos { get; private set; }
    }
}