using UnityEngine;

namespace BOYAREGames.Collectable
{
    public class Chest : MonoBehaviour
    {
        [SerializeField] private int _amount;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player.Player player))
            {
                Managers.instance.ResourcesManager.Add(Resources.ResourceType.Gold, _amount);
                Destroy(gameObject);
            }
        }
    }
}
