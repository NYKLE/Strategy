using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainResource
{
    private  float Gold;
    private  float Population;
    private  float Food;
    private  float Contentment;

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
    public float LoseResourse(MainResourceType type, float count)
    {
        switch (type)
        {
            case MainResourceType.Gold:
                if (Gold < count) Gold = 0;
                else Gold -= count;
                return Gold;
            case MainResourceType.Food:
                if (Food < count) Food = 0;
                else Food -= count;
                return  Food;
            case MainResourceType.Population:
                if (Population < count) Population = 0;
                else Population -= count;
                return Population;
            case MainResourceType.Contentment:
                if (Contentment < count) Contentment = 0;
                else Contentment -= count;
                return Contentment;
            default:
                return 0;
        }
         Debug.Log("count = " + count + "type = " + type);
    }
    
}
