using UnityEngine;
using System;
public class CollisionComponent : MonoBehaviour
{
    private Action collectCoin;
    public Action<Collider> OnEnter = (col) => { };
    public bool IsCoinsInRadius { get; private set; }
    public void OnTriggerEnter(Collider other)
    {
        var coin = other.gameObject.GetComponent<Coin>();
        if (coin)
        {
           OnEnter.Invoke(other);
        }
    }
}
