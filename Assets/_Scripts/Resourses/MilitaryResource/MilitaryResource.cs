using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MilitaryResource : MonoBehaviour
{
    private float Armor;
    private float MilitaryWeapon;

    public static event Action<MilitaryResourceType, float> AddRes;
    public static event Action<MilitaryResourceType, float> LoseRes;
    public void AddResource(MilitaryResourceType type, float count)
    {

        switch (type)
        {
            case MilitaryResourceType.Armor:
                Armor += count;
                break;
            case MilitaryResourceType.MilitaryWeapon:
                MilitaryWeapon += count;
                break;
        }
    }
    public void LoseResourse(MilitaryResourceType type, float count)
    {
        switch (type)
        {
            case MilitaryResourceType.Armor:
                if (Armor < count) Armor = 0;
                else Armor -= count;
                break;
            case MilitaryResourceType.MilitaryWeapon:
                if (MilitaryWeapon < count) MilitaryWeapon = 0;
                else MilitaryWeapon -= count;
                break; ;
            default:
                break;
        }
    }
}
