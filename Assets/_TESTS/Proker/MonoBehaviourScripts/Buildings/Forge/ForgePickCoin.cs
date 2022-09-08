using UnityEngine;

namespace BOYAREGames.Buildings
{
    [RequireComponent(typeof(Forge))]
    [RequireComponent(typeof(SphereCollider))]
    public class ForgePickCoin : MonoBehaviour
    {
        [SerializeField] private float _coinSightRadius = 10f;

        private Forge _forge;
        private SphereCollider _sphereCollider;

        private void Awake()
        {
            _forge = GetComponent<Forge>();
            _sphereCollider = GetComponent<SphereCollider>();
        }

        private void Start()
        {
            _sphereCollider.radius = _coinSightRadius;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Collectable.Coin coin))
            {
                _forge.AddCoin(1);
                Destroy(coin.gameObject);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _coinSightRadius);
        }
    }
}
