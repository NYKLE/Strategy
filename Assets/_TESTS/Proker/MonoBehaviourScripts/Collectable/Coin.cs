using System.Collections;
using UnityEngine;

namespace BOYAREGames.Collectable
{
    public class Coin : MonoBehaviour
    {
        public bool IsDroppedByPlayer = false;
        [SerializeField] private float _untouchableDuration = 3f;

        private Coroutine _enableColliderCoroutine;
        private WaitForSeconds _waitForUntouchableDuration;

        private bool _canPlayerPickUp;

        private void Awake()
        {
            _waitForUntouchableDuration = new WaitForSeconds(_untouchableDuration);
        }

        private void Start()
        {
            if (IsDroppedByPlayer)
            {
                _enableColliderCoroutine ??= StartCoroutine(EnableCollider());
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player.Player player) && _canPlayerPickUp)
            {
                Managers.instance.ResourcesManager.Add(Resources.ResourceType.Gold, 1);
                Destroy(gameObject);
            }
        }

        private IEnumerator EnableCollider()
        {
            yield return _waitForUntouchableDuration;

            _canPlayerPickUp = true;

            _enableColliderCoroutine = null;
        }
    }
}
