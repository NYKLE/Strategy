using UnityEngine;
using System;
public class CollisionComponent : MonoBehaviour
{
    private Action collectCoin;
    
    public bool IsCoinsInRadius { get; private set; }
    public void OnTriggerEnter(Collider other)
    {
        var coin = other.gameObject.GetComponent<Coin>();
        if (coin)
        {
            coin.Hide();
            collectCoin.Invoke();
        }
    }
    
    public void AddAction(Action _collectCoin)
    {
        collectCoin = _collectCoin;
    }
}
