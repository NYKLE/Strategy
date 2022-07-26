using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryResource : MonoBehaviour
{
    private float Armor;
    private float MilitaryWeapon;
   

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
    public float LoseResourse(MilitaryResourceType type, float count)
    {
        switch (type)
        {
            case MilitaryResourceType.Armor:
                if (Armor < count) Armor = 0;
                else Armor -= count;
                return Armor;
            case MilitaryResourceType.MilitaryWeapon:
                if (MilitaryWeapon < count) MilitaryWeapon = 0;
                else MilitaryWeapon -= count;
                return MilitaryWeapon;
            default:
                return 0;
        }
    }
}
