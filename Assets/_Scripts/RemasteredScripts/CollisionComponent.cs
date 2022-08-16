using UnityEngine;
using System;
public class CollisionComponent : MonoBehaviour
{
    private Action collectCoin;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Coin>())
        {
            collectCoin.Invoke();
        }
    }
    public void AddAction(Action _collectCoin)
    {
        collectCoin = _collectCoin;
    }
}
