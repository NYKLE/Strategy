using UnityEngine;

public class PlayerDropCoin : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Managers.instance.ResourcesManager.Get(BOYAREGames.Resources.ResourceType.Gold) > 0)
            {
                Managers.instance.ResourcesManager.Add(BOYAREGames.Resources.ResourceType.Gold, -1);
                var go = Instantiate(_coinPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
