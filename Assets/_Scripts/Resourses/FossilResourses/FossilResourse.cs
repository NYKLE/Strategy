using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FossilResourse : MonoBehaviour
{
    private float Wood;
    private float Iron;
    private float Stone;

    public void AddResource(FoosilType type, float count)
    {

        switch (type)
        {
            case FoosilType.Wood:
                Wood += count;
                break;
            case FoosilType.Iron:
                Iron += count;
                break;
            case FoosilType.Stone:
                Stone += count;
                break;
        }
    }
    public float LoseResourse(FoosilType type, float count)
    {
        switch (type)
        {
            case FoosilType.Wood:
                if (Wood < count) Wood = 0;
                else Wood -= count;
                return Wood;
            case FoosilType.Iron:
                if (Iron < count) Iron = 0;
                else Iron -= count;
                return Iron;
            case FoosilType.Stone:
                if (Stone < count) Stone = 0;
                else Stone -= count;
                return Stone;
            default:
                return 0;
        }
    }
}
