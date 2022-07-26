using UnityEngine;

public class BuildingsManager : MonoBehaviour
{
    public static BuildingsManager Instance;

    [SerializeField] private TownHall _townHall;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public TownHall GetTownHall()
    {
        return _townHall;
    }
}
