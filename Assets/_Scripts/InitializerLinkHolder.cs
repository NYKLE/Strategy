using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializerLinkHolder : MonoBehaviour
{
    private ResourseGeneric resourses;
    public BuildingsManager BuildingsManager { get; private set; }

    void Start()
    {
        resourses.InitRes();
         var gold = resourses.GetResource(ResourceType.Gold);
        resourses.SetResourse(ResourceType.Gold, gold + 1);
        // var armor = resourses.GetResource(ResourceType.Armor);
        // resourses.SetResourse(ResourceType.Armor, armor + 1);
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
       BuildingsManager = new BuildingsManager();
    }

    private void Subscribe()
    {
    }
    private void UnSubscribe()
    {
    }

}
