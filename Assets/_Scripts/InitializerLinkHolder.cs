using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializerLinkHolder : MonoBehaviour
{
    private ResourseGeneric resourses;

    void Start()
    {
        resourses.InitRes();
         var gold = resourses.GetResource(ResourseType.Gold);
        resourses.SetResourse(ResourseType.Gold, gold + 1);
        var armor = resourses.GetResource(ResourseType.Armor);
        resourses.SetResourse(ResourseType.Armor, armor + 1);
    }
    private void OnEnable()
    {
        Initialized();
        Subscribe();
    }
    private void OnDisable()
    {
        UnSubscribe();
    }
    private void Initialized()
    {
       resourses = new ResourseGeneric();
    }

    private void Subscribe()
    {
    }
    private void UnSubscribe()
    {
    }

}
