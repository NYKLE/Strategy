using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _untouchableTime = 4f;
    public bool CanPickUp { get; set; }

    private WaitForSeconds _waitForSeconds;

    public void Hide()
    {
        // TODO: Hide effect

        Destroy(gameObject);
    }

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_untouchableTime);
    }

    private void Start()
    {
        StartCoroutine(UntouchableCoroutine());
    }

    private IEnumerator UntouchableCoroutine()
    {
        yield return _waitForSeconds;
        CanPickUp = true;
    }
}
