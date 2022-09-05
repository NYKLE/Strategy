using BOYAREGames.Resources;
using UnityEngine;

[RequireComponent(typeof(TimeManager))]
public class Managers : MonoBehaviour
{
    public static Managers instance;

    public TimeManager Time { get; private set; }
    public ResourcesManager ResourcesManager { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Time = GetComponent<TimeManager>();
        ResourcesManager = GetComponent<ResourcesManager>();
    }
}
