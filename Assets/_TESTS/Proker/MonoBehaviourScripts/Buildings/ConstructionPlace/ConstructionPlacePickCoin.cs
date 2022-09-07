using UnityEngine;

namespace BOYAREGames.Buildings
{
    [RequireComponent(typeof(ConstructionPlace))]
    [RequireComponent(typeof(SphereCollider))]
    public class ConstructionPlacePickCoin : MonoBehaviour
    {
        [SerializeField] private float _coinSightRadius = 10f;

        private ConstructionPlace _constructionPlace;
        private SphereCollider _sphereCollider;

        private void Awake()
        {
            _constructionPlace = GetComponent<ConstructionPlace>();
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
                _constructionPlace.AddCoin(1);
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
