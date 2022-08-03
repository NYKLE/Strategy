using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers instance;
    [field: SerializeField] public Cursor Cursor { get; private set; }
    [field: SerializeField] public TimeManager Time { get; private set; }
    [field: SerializeField] public UnitsManager UnitsManager { get; private set; }
    [field: SerializeField] public WorkerManager WorkerManager { get; private set; }
    public BuildingsManager BuildingsManager { get; private set; }
    public ResourceManager ResourceManager { get; private set; }

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

        BuildingsManager = new BuildingsManager();
        ResourceManager = new ResourceManager();
    }
}
