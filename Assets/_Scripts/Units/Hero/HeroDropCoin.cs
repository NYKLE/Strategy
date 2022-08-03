using UnityEngine;

public class HeroDropCoin : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var coin = Instantiate(_coinPrefab, transform.position, Quaternion.identity);
        }
    }
}
