using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializerLinkHolder : MonoBehaviour
{
    public MainResource _mainResourses { get; private set; }
    public FossilResourse _fossilResourse { get; private set; }
    public MilitaryResource _militaryResource { get; private set; }


    private static InitializerLinkHolder instance;

    public static InitializerLinkHolder getInstance()
    {
       return instance;
    }
    void Start()
    {
        if (instance == null)
            instance = this;

       Initialized();
    }

    private void Initialized()
    {
       _mainResourses = new MainResource();
        _fossilResourse = new FossilResourse();
        _militaryResource = new MilitaryResource();
    }
   
}
