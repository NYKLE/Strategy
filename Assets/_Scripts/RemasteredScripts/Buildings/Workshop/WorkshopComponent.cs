using UnityEngine;

namespace GameInit.Component
{
    public class WorkshopComponent : MonoBehaviour
    {
        public ToolType ToolType { get; set; }
        [SerializeField] private GameObject _pitchforkPrefab;
        [SerializeField] private GameObject _hammerPrefab;
        [SerializeField] private GameObject _swordPrefab;
        [SerializeField] private GameObject _bowPrefab;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Transform _toolSpawnPointTransform;
    }
}
