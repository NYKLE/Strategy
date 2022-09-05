using UnityEngine;

public abstract class BuildingBase : MonoBehaviour
{
    [field: SerializeField] public BuildingType Type { get; private set; }
    [field: SerializeField] public BuildingState State { get; set; }
    [field: SerializeField] public int HealthMax { get; set; }
    [field: SerializeField] public int HealthCurrent { get; set; }
    [field: SerializeField] public int Level { get; set; } = 1;

    private float _multiplier = 1.25f;

    private void Awake()
    {
        HealthCurrent = HealthMax;
    }

    public virtual void Start() { }

    public virtual void Upgrade()
    {
        if (Level < 3 && State == BuildingState.Full)
        {
            Level++;
            int newHealthMax = (int)(HealthMax * _multiplier);
            HealthMax = newHealthMax;
            HealthCurrent = newHealthMax;
        }
    }

    public virtual void OnEnable()
    {
        //Managers.instance.BuildingsManager.AddBuilding(this);
    }

    public virtual void OnDisable()
    {
        //Managers.instance.BuildingsManager.RemoveBuilding(this);
    }
}
