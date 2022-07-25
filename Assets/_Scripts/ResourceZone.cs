using UnityEngine;

public class ResourceZone : MonoBehaviour, ISelectable
{
    [SerializeField] private ResourceType _resourceType;

    public void OnSelect()
    {
        Debug.Log($"Type: {_resourceType.ToString()}");
    }
}
