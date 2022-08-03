using System;
using System.Collections.Generic;

[Serializable]
public class ResourceManager
{
    private Dictionary<ResourceType, int> _resources;

    public ResourceManager()
    {
        _resources = new Dictionary<ResourceType, int>();
        foreach (var resType in Enum.GetNames(typeof(ResourceType)))
        {
            _resources.Add((ResourceType)Enum.Parse(typeof(ResourceType), resType), 0);
        }
    }

    public int GetResource(ResourceType type)
    {
        if (_resources.ContainsKey(type))
        {
            return _resources.GetValueOrDefault(type);
        }
        return 0;
    }

    public void SetResource(ResourceType type, int count)
    {
        if (_resources.ContainsKey(type))
        {
            _resources[type] = count;
        }
    }
}
