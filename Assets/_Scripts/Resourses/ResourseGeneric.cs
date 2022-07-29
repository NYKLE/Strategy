using System;
using System.Collections.Generic;

public class ResourseGeneric
{
    private Dictionary<ResourseType, int> resourses;
    
    public void InitRes()
    {
        resourses = new Dictionary<ResourseType, int>();
        foreach (var resType in Enum.GetNames(typeof(ResourseType)))
        {
            resourses.Add((ResourseType)Enum.Parse(typeof(ResourseType), resType), 0);
        }
    }
    public int GetResource(ResourseType type)
    {
        if (resourses.ContainsKey(type))
        {
            return resourses.GetValueOrDefault(type);
        }
        return 0;
    }

    public void SetResourse(ResourseType type, int count)
    {
        if (resourses.ContainsKey(type))
        {
           resourses[type] = count;
        }
    }
}
