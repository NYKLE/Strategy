using UnityEngine;

namespace BOYAREGames.Player
{
    public class PlayerDropCoin : MonoBehaviour
    {
        [SerializeField] private GameObject _coinPrefab;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DropCoin();
            }
        }

        private void DropCoin()
        {
            if (Managers.instance.ResourcesManager.Get(Resources.ResourceType.Gold) > 0)
            {
                Managers.instance.ResourcesManager.Add(Resources.ResourceType.Gold, -1);
                var go = Instantiate(_coinPrefab, transform.position, Quaternion.identity);
                if (go.TryGetComponent(out Collectable.Coin coin))
                {
                    coin.IsDroppedByPlayer = true;
                }
            }
        }

        private void OnEnable()
        {
            Events.Events.Player.DropCoin += DropCoin;
        }

        private void OnDisable()
        {
            Events.Events.Player.DropCoin -= DropCoin;
        }
    }
}
