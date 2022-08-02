using System;
using System.Collections.Generic;

public class ResourseGeneric
{
    private Dictionary<ResourceType, int> resourses;
    
    public void InitRes()
    {
        resourses = new Dictionary<ResourceType, int>();
        foreach (var resType in Enum.GetNames(typeof(ResourceType)))
        {
            resourses.Add((ResourceType)Enum.Parse(typeof(ResourceType), resType), 0);
        }
    }
    public int GetResource(ResourceType type)
    {
        if (resourses.ContainsKey(type))
        {
            return resourses.GetValueOrDefault(type);
        }
        return 0;
    }

    public void SetResourse(ResourceType type, int count)
    {
        if (resourses.ContainsKey(type))
        {
           resourses[type] = count;
        }
    }
}
