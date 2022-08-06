using UnityEngine;

public class ChestSettings : MonoBehaviour
{
    [field: SerializeField] public int GoldAmount { get; private set; }
    [field: SerializeField] public float ColliderRadius { get; private set; }
    public Transform Transform { get; private set; }


    private void Awake()
    {
        Transform = transform;
    }
}
