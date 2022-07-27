using UnityEngine;

public class ResourceZoneAddOrReleaseWorkerButton : MonoBehaviour
{
    private ResourceZone _zone;

    public void OnAdd()
    {
        if (_zone.GetWorkers().Count < 10)
        {
            SetWorker();
        }
    }

    public void OnRelease()
    {
        if (_zone.GetWorkers().Count > 0)
        {
            ReturnWorker();
        }
    }

    public void SetZone(ResourceZone zone)
    {
        _zone = zone;
    }

    private void SetWorker()
    {
        for (int i = 0; i < WorkerManager.Instance.GetWorkers().Count; i++)
        {
            if (WorkerManager.Instance.GetWorkers()[i].GetState() == WorkerState.Free)
            {
                WorkerManager.Instance.GetWorkers()[i].SendToWork(_zone.GetEnterExitPoint(), _zone);
                _zone.UpdateWindowData();
                break;
            }
        }


        // if (WorkerManager.Instance.CheckForFreeWorkers().Count > 0)
        // {
        //     WorkerManager.Instance.CheckForFreeWorkers()[0].SendToWork(_zone.GetEnterExitPoint(), _zone);
        // }
        //
        // _zone.UpdateWindowData();
    }

    private void ReturnWorker()
    {
        for (int i = 0; i < WorkerManager.Instance.GetWorkers().Count; i++)
        {
            if (WorkerManager.Instance.GetWorkers()[i].GetResourceZone() == _zone && WorkerManager.Instance.GetWorkers()[i].GetState() == WorkerState.Working)
            {
                WorkerManager.Instance.GetWorkers()[i].ReturnWorker(BuildingsManager.Instance.GetTownHall().GetSpawnPoint(), _zone);
                _zone.UpdateWindowData();
                break;
            }
        }
    }
}
