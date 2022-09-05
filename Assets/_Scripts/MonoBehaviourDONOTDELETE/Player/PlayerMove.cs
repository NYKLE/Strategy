using UnityEngine;
using UnityEngine.AI;

namespace BOYAREGames.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystemMoveTo;

        private RaycastHit _raycastHit;
        private LayerMask _layerMask;

        private NavMeshAgent _agent;
        private bool _RMBIsPressed;

        public void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();

            _layerMask = 1 >> 0; // Default Layer
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(1))
                _RMBIsPressed = true;

            if (Input.GetMouseButtonUp(1))
                _RMBIsPressed = false;

            if (!_RMBIsPressed) return;

            if (Physics.Raycast(
                    Camera.main.ScreenPointToRay(Input.mousePosition),
                    out _raycastHit,
                    Mathf.Infinity,
                    _layerMask,
                    QueryTriggerInteraction.Ignore))
            {
                _agent.SetDestination(_raycastHit.point);

                _particleSystemMoveTo.transform.position = _raycastHit.point;
                _particleSystemMoveTo.Play();
            }
        }
    }
}
