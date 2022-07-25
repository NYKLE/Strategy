using UnityEngine;

public class ResourceZoneButtonUI : MonoBehaviour
{
    private ResourceZone _zone;

    private bool _isOccupied;

    public void OnClick()
    {
        if (_isOccupied)
        {
            // TODO: ResourceZoneButtonUI DO Active Thing
            Debug.Log("Occupied");
        }
        else
        {
            SetWorker();
        }
    }

    public void SetOccupied(bool isOccupied)
    {
        _isOccupied = isOccupied;
    }

    public void SetZone(ResourceZone zone)
    {
        _zone = zone;
    }

    private void SetWorker()
    {
        if (WorkerManager.Instance.CheckForFreeWorkers().Count > 0)
        {
            WorkerManager.Instance.CheckForFreeWorkers()[0].SendToWork(_zone.transform.position, _zone);
        }
    }
}
