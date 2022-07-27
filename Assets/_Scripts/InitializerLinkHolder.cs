using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializerLinkHolder : MonoBehaviour
{
    public MainResource _mainResourses { get; private set; }
    public FossilResourse _fossilResourse { get; private set; }
    public MilitaryResource _militaryResource { get; private set; }

    void Start()
    {
       
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
       _mainResourses = new MainResource();
        _fossilResourse = new FossilResourse();
        _militaryResource = new MilitaryResource();
    }

    private void Subscribe()
    {
        MainResource.AddRes += _mainResourses.AddResource;
        MainResource.LoseRes += _mainResourses.LoseResourse;

        FossilResourse.AddRes += _fossilResourse.AddResource;
        FossilResourse.LoseRes += _fossilResourse.LoseResourse;

        MilitaryResource.AddRes += _militaryResource.AddResource;
        MilitaryResource.LoseRes += _militaryResource.LoseResourse;
    }
    private void UnSubscribe()
    {
        MainResource.AddRes -= _mainResourses.AddResource;
        MainResource.LoseRes -= _mainResourses.LoseResourse;

        FossilResourse.AddRes -= _fossilResourse.AddResource;
        FossilResourse.LoseRes -= _fossilResourse.LoseResourse;

        MilitaryResource.AddRes -= _militaryResource.AddResource;
        MilitaryResource.LoseRes -= _militaryResource.LoseResourse;
    }

}
