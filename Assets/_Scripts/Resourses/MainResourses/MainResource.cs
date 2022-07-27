using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MainResource
{
    private  float Gold;
    private  float Population;
    private  float Food;
    private  float Contentment;

    public static event Action<MainResourceType, float> AddRes;
    public static event Action<MainResourceType, float> LoseRes;
    public void AddResource(MainResourceType type, float count)
    {

        switch (type)
        {
            case MainResourceType.Gold:
                Gold += count;
                break;
            case MainResourceType.Food:
                Food += count;
                break;
            case MainResourceType.Population:
                Population += count;
                break;
            case MainResourceType.Contentment:
                Contentment += count;
                break;
        }
        Debug.Log("count = " + count + "type = " + type);
    }
    public void LoseResourse(MainResourceType type, float count)
    {
        switch (type)
        {
            case MainResourceType.Gold:
                if (Gold < count) Gold = 0;
                else Gold -= count;
                break;
            case MainResourceType.Food:
                if (Food < count) Food = 0;
                else Food -= count;
                break;
            case MainResourceType.Population:
                if (Population < count) Population = 0;
                else Population -= count;
                break;
            case MainResourceType.Contentment:
                if (Contentment < count) Contentment = 0;
                else Contentment -= count;
                break;
            default:
                break;
        }
         Debug.Log("count = " + count + "type = " + type);
    }
    
}
