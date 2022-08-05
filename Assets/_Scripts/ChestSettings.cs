using System.Collections.Generic;
using GameInit.Chest;
using UnityEngine;

public class ChestSettings : MonoBehaviour
{
    [field: SerializeField] public int GoldAmount { get; private set; }
    [field: SerializeField] public float ColliderRadius { get; private set; }
    public Transform Transform { get; private set; }
    public int Id { get; private set; }


    private void Awake()
    {
        Transform = transform;
        Id = GetInstanceID();
    }
}
